using Tycho.Messaging.Handlers;
using TychoWebsite.Topics.Core;

namespace TychoWebsite.Topics.Contract.Handlers;

internal class CreateTopicCommandHandler : ICommandHandler<CreateTopicCommand>
{
    private readonly ITopicsRepository _topicsRepository;

    public CreateTopicCommandHandler(ITopicsRepository topicsRepository)
    {
        _topicsRepository = topicsRepository;
    }

    public Task Handle(CreateTopicCommand commandData, CancellationToken cancellationToken)
    {
        return _topicsRepository.CreateTopic(commandData.Topic, cancellationToken);
    }
}
