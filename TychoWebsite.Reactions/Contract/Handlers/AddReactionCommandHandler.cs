using Tycho.Messaging.Handlers;
using TychoWebsite.Reactions.Core;

namespace TychoWebsite.Reactions.Contract.Handlers;

internal class AddReactionCommandHandler : ICommandHandler<AddReactionCommand>
{
    private readonly IReactionsRepository _reactionsRepository;

    public AddReactionCommandHandler(IReactionsRepository reactionsRepository)
    {
        _reactionsRepository = reactionsRepository;
    }

    public Task Handle(AddReactionCommand commandData, CancellationToken cancellationToken)
    {
        return _reactionsRepository.AddReaction(commandData.Reaction, cancellationToken);
    }
}
