using Tycho.Messaging.Handlers;
using TychoWebsite.Topics.Contract.Model;

namespace TychoWebsite.Topics.Contract.Handlers;

internal class GetTopicQueryHandler : IQueryHandler<GetTopicQuery, Topic>
{
    public Task<Topic> Handle(GetTopicQuery queryData, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<Topic>(default!);
    }
}
