using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Core.Ports;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class PublishPostCommandHandler : ICommandHandler<PublishPostCommand>
{
    private readonly IPostsRepository _postsRepository;

    public PublishPostCommandHandler(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    public Task Handle(PublishPostCommand commandData, CancellationToken cancellationToken)
    {
        return _postsRepository.CreatePost(commandData.Post, cancellationToken);
    }
}
