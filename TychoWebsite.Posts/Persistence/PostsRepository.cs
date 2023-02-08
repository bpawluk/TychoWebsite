using MongoDB.Driver;
using TychoWebsite.Posts.Contract.Model.Posts;
using TychoWebsite.Posts.Core.Ports;
using TychoWebsite.Posts.Persistence.Entities;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Posts.Persistence;

internal class PostsRepository : RepositoryBase<NewPost, PostEntity, Post>, IPostsRepository
{
    private readonly IPostScoreProvider _scoreProvider;
    private readonly IPostingTopicProvider _topicProvider;

    public PostsRepository(IPostScoreProvider scoreProvider, IPostingTopicProvider topicProvider)
        : base(new RepositorySettings(@"mongodb://localhost:27017", "postsModule", "posts"))
    {
        _scoreProvider = scoreProvider;
        _topicProvider = topicProvider;
    }

    public Task CreatePost(NewPost post, CancellationToken token) => InsertOne(post, token);

    public Task<IEnumerable<Post>> GetAllPosts(CancellationToken token) => GetAll(token);

    public async Task<IEnumerable<Post>> GetPostsWithTags(IEnumerable<string> tags, CancellationToken token)
    {
        var filter = Builders<PostEntity>.Filter.AnyIn(entity => entity.Tags, tags);
        var entities = await FindEntities(filter, token);
        return await MapAllToModel(entities, token);
    }

    public async Task<IEnumerable<Post>> GetPostsWithTopic(string topicId, CancellationToken token)
    {
        var filter = Builders<PostEntity>.Filter.Eq(entity => entity.TopicId, topicId);
        var entities = await FindEntities(filter, token);
        return await MapAllToModel(entities, token);
    }

    protected override Task<PostEntity> MapToEntity(NewPost model, CancellationToken token)
    {
        return Task.FromResult(new PostEntity()
        {
            Id = model.Id,
            Author = new() { Id = model.Author.Id, Name = model.Author.Name },
            TopicId = model.TopicId,
            Content = model.Content,
            PublishingDate = DateTime.UtcNow,
            Tags = model.Tags,
            IsArchived = false
        });
    }

    protected override async Task<Post> MapToModel(PostEntity entity, CancellationToken token)
    {
        var score = await _scoreProvider.GetScore(entity.Id, token);
        var topic = entity.TopicId is null ? null : await _topicProvider.GetTopic(entity.TopicId, token);
        return new Post(
            entity.Id,
            entity.Content,
            new(entity.Author.Id, entity.Author.Name),
            score,
            entity.PublishingDate,
            entity.Tags,
            topic);
    }

    protected override async Task<IEnumerable<Post>> MapAllToModel(IEnumerable<PostEntity> entities, CancellationToken token)
    {
        entities = entities.ToList();

        var entityIds = entities.Select(entity => entity.Id);
        var scores = await _scoreProvider.GetScores(entityIds, token);

        var topicIds = entities.Select(entity => entity.TopicId!).Where(id => id is not null).Distinct();
        var topics = await _topicProvider.GetTopics(topicIds, token);

        return entities.Select(entity => new Post(
            entity.Id,
            entity.Content,
            new(entity.Author.Id, entity.Author.Name),
            scores.Single(score => score.PostId == entity.Id),
            entity.PublishingDate,
            entity.Tags,
            entity.TopicId is null ? null : topics.Single(topic => topic.Id == entity.TopicId)));
    }
}
