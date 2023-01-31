using Tycho;
using TychoWebsite.Posts.Contract.Model;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model.Posts;
using TychoWebsite.Posts.Core.Ports;

namespace TychoWebsite.Posts.External;

internal class PostingTopicProvider : IPostingTopicProvider
{
    private readonly IModule _thisModule;

    public PostingTopicProvider(IModule thisModule)
    {
        _thisModule = thisModule;
    }

    public async Task<PostingTopic> GetTopic(string topicId, CancellationToken token)
    {
        return (await GetTopics(new[] { topicId }, token)).Single();
    }

    public Task<IEnumerable<PostingTopic>> GetTopics(IEnumerable<string> topicIds, CancellationToken token)
    {
        return _thisModule.Execute<GetPostingTopicsQuery, IEnumerable<PostingTopic>>(new(topicIds), token);
    }
}
