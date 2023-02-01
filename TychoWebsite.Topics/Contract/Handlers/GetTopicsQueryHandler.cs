using Tycho.Messaging.Handlers;
using TychoWebsite.Topics.Contract.Model;
using TychoWebsite.Topics.Core;

namespace TychoWebsite.Topics.Contract.Handlers;

internal class GetTopicsQueryHandler : IQueryHandler<GetTopicsQuery, IEnumerable<Topic>>
{
    private readonly ITopicsRepository _topicsRepository;

    public GetTopicsQueryHandler(ITopicsRepository topicsRepository)
    {
        _topicsRepository = topicsRepository;
    }

    public Task<IEnumerable<Topic>> Handle(GetTopicsQuery queryData, CancellationToken cancellationToken = default)
    {
        return _topicsRepository.GetTopics(queryData.TopicIds, cancellationToken);
    }
}
