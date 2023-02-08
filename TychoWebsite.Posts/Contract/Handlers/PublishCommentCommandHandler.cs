using Tycho;
using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Core.Ports;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class PublishCommentCommandHandler : ICommandHandler<PublishCommentCommand>
{
    private readonly IModule _thisModule;
    private readonly ICommentsRepository _commentsRepository;

    public PublishCommentCommandHandler(IModule thisModule, ICommentsRepository commentsRepository)
    {
        _thisModule = thisModule;
        _commentsRepository = commentsRepository;
    }

    public async Task Handle(PublishCommentCommand commandData, CancellationToken cancellationToken)
    {
        await _commentsRepository.CreateComment(commandData.Comment, cancellationToken);
        _thisModule.Publish<CommentPublishedEvent>(new(commandData.Comment.Id), cancellationToken);
    }
}
