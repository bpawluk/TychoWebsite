using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Contract;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class PublishPostCommandHandler : ICommandHandler<PublishPostCommand>
{
    public Task Handle(PublishPostCommand commandData, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
