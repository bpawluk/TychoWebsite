using Tycho.Messaging.Handlers;

namespace TychoWebsite.Topics.Contract.Handlers;

internal class CreateTopicCommandHandler : ICommandHandler<CreateTopicCommand>
{
    public Task Handle(CreateTopicCommand commandData, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
