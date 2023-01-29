using Tycho.Messaging.Handlers;
using TychoWebsite.Reactions.Contract.Model;

namespace TychoWebsite.Reactions.Contract.Handlers;

internal class GetScoreQueryHandler : IQueryHandler<GetScoreQuery, Score>
{
    public Task<Score> Handle(GetScoreQuery queryData, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<Score>(default!);
    }
}
