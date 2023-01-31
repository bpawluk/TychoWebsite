using TychoWebsite.Posts.Contract.Model.Posts;

namespace TychoWebsite.Posts.Core.Ports;

internal interface IPostingTopicProvider
{
    Task<PostingTopic> GetTopic(string topicId, CancellationToken token);
    Task<IEnumerable<PostingTopic>> GetTopics(IEnumerable<string> topicIds, CancellationToken token);
}
