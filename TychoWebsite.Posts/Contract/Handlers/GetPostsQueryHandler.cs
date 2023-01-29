using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class GetPostsQueryHandler : IQueryHandler<GetPostsQuery, IEnumerable<Post>>
{
    public Task<IEnumerable<Post>> Handle(GetPostsQuery queryData, CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Empty<Post>());
    }
}
