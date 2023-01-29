using Tycho.Messaging.Handlers;

namespace TychoWebsite.Articles.Contract.Handlers;

internal class PublishArticleCommandHandler : ICommandHandler<PublishArticleCommand>
{
    public Task Handle(PublishArticleCommand commandData, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
