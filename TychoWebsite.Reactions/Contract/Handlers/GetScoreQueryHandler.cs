using Tycho.Messaging.Handlers;
using TychoWebsite.Reactions.Contract.Model;
using TychoWebsite.Reactions.Core;

namespace TychoWebsite.Reactions.Contract.Handlers;

internal class GetScoreQueryHandler : IQueryHandler<GetScoreQuery, Score>
{
    private readonly IReactionsRepository _reactionsRepository;

    public GetScoreQueryHandler(IReactionsRepository reactionsRepository)
    {
        _reactionsRepository = reactionsRepository;
    }

    public Task<Score> Handle(GetScoreQuery queryData, CancellationToken cancellationToken = default)
    {
        return _reactionsRepository.GetScore(queryData.SubjectId, cancellationToken);
    }
}
