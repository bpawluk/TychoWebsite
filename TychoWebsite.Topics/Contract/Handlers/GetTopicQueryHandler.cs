using Tycho.Messaging.Handlers;
using TychoWebsite.Topics.Contract.Model;
using TychoWebsite.Topics.Core;

namespace TychoWebsite.Topics.Contract.Handlers;

internal class GetTopicQueryHandler : IQueryHandler<GetTopicQuery, Topic>
{
    private readonly ITopicsRepository _topicsRepository;

    public GetTopicQueryHandler(ITopicsRepository topicsRepository)
    {
        _topicsRepository = topicsRepository;
    }

    public Task<Topic> Handle(GetTopicQuery queryData, CancellationToken cancellationToken = default)
    {
        return _topicsRepository.GetTopic(queryData.TopicId, cancellationToken);
    }
}
