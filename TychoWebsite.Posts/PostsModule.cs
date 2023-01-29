using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Handlers;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.Posts;

public sealed class PostsModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.Executes<PublishPostCommand, PublishPostCommandHandler>()
              .RespondsTo<GetPostsQuery, IEnumerable<Post>, GetPostsQueryHandler>();

        module.Executes<PublishCommentCommand, PublishCommentCommandHandler>()
              .RespondsTo<GetCommentsQuery, IEnumerable<Comment>, GetCommentsQueryHandler>();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) 
    {
        module.Sends<GetPostingTopicQuery, PostingTopic>()
              .Sends<GetPostsScoresQuery, IEnumerable<PostScore>>();
              
        module.Sends<GetCommentsScoresQuery, IEnumerable<CommentScore>>();
    }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services) { }
}