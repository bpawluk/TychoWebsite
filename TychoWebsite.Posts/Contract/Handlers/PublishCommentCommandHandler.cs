using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Contract;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class PublishCommentCommandHandler : ICommandHandler<PublishCommentCommand>
{
    public Task Handle(PublishCommentCommand commandData, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
