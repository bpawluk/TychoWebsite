using TychoWebsite.Posts.Contract.Model.Posts;

namespace TychoWebsite.Posts.Core.Ports;

internal interface IPostsRepository
{
    Task CreatePost(NewPost post, CancellationToken token);
    Task<IEnumerable<Post>> GetAllPosts(CancellationToken token);
    Task<IEnumerable<Post>> GetPostsWithTags(IEnumerable<string> tags, CancellationToken token);
}
