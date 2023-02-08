using MongoDB.Driver;
using TychoWebsite.Posts.Contract.Model;
using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Core.Ports;
using TychoWebsite.Posts.Persistence.Entities;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Posts.Persistence;

internal class CommentsRepository : RepositoryBase<NewComment, CommentEntity, Comment>, ICommentsRepository
{
    private readonly ICommentScoresProvider _scoreProvider;

    public CommentsRepository(ICommentScoresProvider scoreProvider) 
        : base(new RepositorySettings(@"mongodb://localhost:27017", "postsModule", "comments")) 
    {
        _scoreProvider = scoreProvider;
    }

    public async Task Init()
    {
        var indexKeysDefinition = Builders<CommentEntity>.IndexKeys.Ascending(comment => comment.PostId);
        await _collection.Indexes.CreateOneAsync(new CreateIndexModel<CommentEntity>(indexKeysDefinition));
    }

    public Task CreateComment(NewComment comment, CancellationToken token) => InsertOne(comment, token);

    public async Task<IEnumerable<Comment>> GetComments(string postId, CancellationToken token)
    {
        var filter = Builders<CommentEntity>.Filter.Eq(entity => entity.PostId, postId);
        var entities = await FindEntities(filter, token);
        return await MapAllToModel(entities, token);
    }

    protected override Task<CommentEntity> MapToEntity(NewComment model, CancellationToken token)
    {
        return Task.FromResult(new CommentEntity()
        {
            Id = model.Id,
            PostId = model.PostId,
            Author = new() { Id = model.Author.Id, Name = model.Author.Name },
            Content = model.Content,
            PublishingDate = DateTime.UtcNow,
            IsArchived = false
        });
    }

    protected override async Task<Comment> MapToModel(CommentEntity entity, CancellationToken token)
    {
        var commentScore = await _scoreProvider.GetScore(entity.Id, token);
        return new Comment(
            entity.Id,
            entity.PostId,
            entity.Content,
            new Poster(entity.Author.Id, entity.Author.Name),
            commentScore,
            entity.PublishingDate);
    }

    protected override async Task<IEnumerable<Comment>> MapAllToModel(IEnumerable<CommentEntity> entities, CancellationToken token)
    {
        entities = entities.ToList();

        var entityIds = entities.Select(entity => entity.Id);
        var scores = await _scoreProvider.GetScores(entityIds, token);

        return entities.Select(entity => new Comment(
            entity.Id,
            entity.PostId,
            entity.Content,
            new Poster(entity.Author.Id, entity.Author.Name),
            scores.Single(score => score.CommentId == entity.Id),
            entity.PublishingDate));
    }
}
