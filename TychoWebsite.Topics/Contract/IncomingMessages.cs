using Tycho.Messaging.Payload;
using TychoWebsite.Topics.Contract.Model;

namespace TychoWebsite.Topics.Contract;

public record CreateTopicCommand(Topic Topic) : ICommand;
public record GetTopicQuery(string TopicId) : IQuery<Topic>;
public record GetTopicsQuery(IEnumerable<string> TopicIds) : IQuery<IEnumerable<Topic>>;
