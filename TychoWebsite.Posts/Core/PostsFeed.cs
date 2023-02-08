using TychoWebsite.Posts.Contract.Model.Posts;
using TychoWebsite.Posts.Core.Interface;
using TychoWebsite.Posts.Core.Ports;

namespace TychoWebsite.Posts.Core;

internal class PostsFeed : IPostsFeed
{
    private readonly IPostsRepository _postsRepository;
    private readonly IPostingTopicProvider _topicProvider;

    public PostsFeed(IPostsRepository postsRepository, IPostingTopicProvider topicProvider)
    {
        _postsRepository = postsRepository;
        _topicProvider = topicProvider;
    }

    public async Task<IEnumerable<Post>> GetPosts(string? topicId, IEnumerable<string>? tags, CancellationToken token)
    {
        if (topicId is not null)
        {
            var topic = await _topicProvider.GetTopic(topicId, token);

            if (topic.Tags.Any())
            {
                return await _postsRepository.GetPostsWithTags(topic.Tags, token);
            }
            
            return await _postsRepository.GetPostsWithTopic(topic.Id, token);
        }

        if (tags?.Any() is true) 
        {
            return await _postsRepository.GetPostsWithTags(tags, token);
        }

        return await _postsRepository.GetAllPosts(token);
    }
}
