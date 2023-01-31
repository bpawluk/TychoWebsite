using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Contract.Model.Posts;
using TychoWebsite.Posts.Core.Interface;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class GetPostsQueryHandler : IQueryHandler<GetPostsQuery, IEnumerable<Post>>
{
    private readonly IPostsFeed _postsFeed;

    public GetPostsQueryHandler(IPostsFeed postsFeed)
    {
        _postsFeed = postsFeed;
    }

    public Task<IEnumerable<Post>> Handle(GetPostsQuery queryData, CancellationToken cancellationToken)
    {
        return _postsFeed.GetPosts(queryData.TopicId, queryData.Tags, cancellationToken);
    }
}
