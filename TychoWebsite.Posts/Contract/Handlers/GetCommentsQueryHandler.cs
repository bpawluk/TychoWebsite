using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class GetCommentsQueryHandler : IQueryHandler<GetCommentsQuery, IEnumerable<Comment>>
{
    public Task<IEnumerable<Comment>> Handle(GetCommentsQuery queryData, CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Empty<Comment>());
    }
}
