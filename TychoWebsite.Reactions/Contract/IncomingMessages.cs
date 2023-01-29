using Tycho.Messaging.Payload;
using TychoWebsite.Reactions.Contract.Model;

namespace TychoWebsite.Reactions.Contract;

public record AddReactionCommand() : ICommand;
public record GetScoreQuery() : IQuery<Score>;
