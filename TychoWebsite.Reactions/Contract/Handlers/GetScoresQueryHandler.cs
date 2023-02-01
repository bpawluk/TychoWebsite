using Tycho.Messaging.Handlers;
using TychoWebsite.Reactions.Contract.Model;
using TychoWebsite.Reactions.Core;

namespace TychoWebsite.Reactions.Contract.Handlers;

internal class GetScoresQueryHandler : IQueryHandler<GetScoresQuery, IEnumerable<Score>>
{
    private readonly IReactionsRepository _reactionsRepository;

    public GetScoresQueryHandler(IReactionsRepository reactionsRepository)
    {
        _reactionsRepository = reactionsRepository;
    }

    public Task<IEnumerable<Score>> Handle(GetScoresQuery queryData, CancellationToken cancellationToken)
    {
        return _reactionsRepository.GetScores(queryData.SubjectIds, cancellationToken);
    }
}
