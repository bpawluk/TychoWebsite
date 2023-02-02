using Tycho;
using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Core.Ports;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class PublishPostCommandHandler : ICommandHandler<PublishPostCommand>
{
    private readonly IModule _thisModule;
    private readonly IPostsRepository _postsRepository;

    public PublishPostCommandHandler(IModule thisModule, IPostsRepository postsRepository)
    {
        _thisModule = thisModule;
        _postsRepository = postsRepository;
    }

    public async Task Handle(PublishPostCommand commandData, CancellationToken cancellationToken)
    {
        await _postsRepository.CreatePost(commandData.Post, cancellationToken);
        _thisModule.Publish<PostPublishedEvent>(new(commandData.Post.Id), cancellationToken);
    }
}
