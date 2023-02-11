using TychoWebsite.Topics.Contract.Model;

namespace TychoWebsite.Topics.Core;

internal interface ITopicsRepository
{
    Task CreateTopic(NewTopic topic, CancellationToken token);
    Task<Topic> GetTopic(string topicId, CancellationToken token);
    Task<IEnumerable<Topic>> GetTopics(IEnumerable<string> topicIds, CancellationToken token);
}
