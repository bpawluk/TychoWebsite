using Tycho.Messaging.Payload;
using TychoWebsite.Reactions.Contract.Model;

namespace TychoWebsite.Reactions.Contract;

public record AddReactionCommand(Reaction Reaction) : ICommand;
public record GetScoreQuery(string SubjectId) : IQuery<Score>;
public record GetScoresQuery(IEnumerable<string> SubjectIds) : IQuery<IEnumerable<Score>>;
public record NewReactionSubjectAvailableEvent(string SubjectId) : IEvent;
