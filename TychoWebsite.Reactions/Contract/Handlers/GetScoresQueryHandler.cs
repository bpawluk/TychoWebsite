using Tycho.Messaging.Handlers;
using TychoWebsite.Reactions.Contract.Model;

namespace TychoWebsite.Reactions.Contract.Handlers;

internal class GetScoresQueryHandler : IQueryHandler<GetScoresQuery, IEnumerable<Score>>
{
    public Task<IEnumerable<Score>> Handle(GetScoresQuery queryData, CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Empty<Score>());
    }
}
