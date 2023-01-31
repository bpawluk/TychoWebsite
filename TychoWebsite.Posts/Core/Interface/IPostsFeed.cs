using TychoWebsite.Posts.Contract.Model.Posts;

namespace TychoWebsite.Posts.Core.Interface;

internal interface IPostsFeed
{
    Task<IEnumerable<Post>> GetPosts(string? topicId, IEnumerable<string>? tags, CancellationToken token);
}
