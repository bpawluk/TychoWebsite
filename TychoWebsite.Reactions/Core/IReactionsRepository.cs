using TychoWebsite.Reactions.Contract.Model;

namespace TychoWebsite.Reactions.Core;

internal interface IReactionsRepository
{
    Task Init(string subjectId, CancellationToken token);
    Task AddReaction(Reaction topic, CancellationToken token);
    Task<Score> GetScore(string subjectId, CancellationToken token);
    Task<IEnumerable<Score>> GetScores(IEnumerable<string> subjectIds, CancellationToken token);
}
