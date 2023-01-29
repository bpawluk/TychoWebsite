using Tycho.Messaging.Handlers;

namespace TychoWebsite.Reactions.Contract.Handlers;

internal class AddReactionCommandHandler : ICommandHandler<AddReactionCommand>
{
    public Task Handle(AddReactionCommand commandData, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
