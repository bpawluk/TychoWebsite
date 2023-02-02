using Tycho.Messaging.Handlers;
using TychoWebsite.Reactions.Core;

namespace TychoWebsite.Reactions.Contract.Handlers;

internal class NewReactionSubjectAvailableEventHandler : IEventHandler<NewReactionSubjectAvailableEvent>
{
    private readonly IReactionsRepository _reactionsRepository;

    public NewReactionSubjectAvailableEventHandler(IReactionsRepository reactionsRepository)
    {
        _reactionsRepository = reactionsRepository;
    }

    public Task Handle(NewReactionSubjectAvailableEvent eventData, CancellationToken cancellationToken)
    {
        return _reactionsRepository.Init(eventData.SubjectId, cancellationToken);
    }
}
