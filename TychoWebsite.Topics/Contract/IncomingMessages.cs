using Tycho.Messaging.Payload;
using TychoWebsite.Topics.Contract.Model;

namespace TychoWebsite.Topics.Contract;

public record CreateTopicCommand() : ICommand;
public record GetTopicQuery() : IQuery<Topic>;
