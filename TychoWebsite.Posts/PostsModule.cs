using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Handlers;
using TychoWebsite.Posts.Contract.Model;
using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Contract.Model.Posts;
using TychoWebsite.Posts.Core;
using TychoWebsite.Posts.Core.Interface;
using TychoWebsite.Posts.Core.Ports;
using TychoWebsite.Posts.External;
using TychoWebsite.Posts.Persistence;

namespace TychoWebsite.Posts;

public sealed class PostsModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.Executes<PublishPostCommand, PublishPostCommandHandler>()
              .RespondsTo<GetPostsQuery, IEnumerable<Post>, GetPostsQueryHandler>()
              .Executes<PublishCommentCommand, PublishCommentCommandHandler>()
              .RespondsTo<GetCommentsQuery, IEnumerable<Comment>, GetCommentsQueryHandler>();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) 
    {
        module.Sends<GetPostingTopicsQuery, IEnumerable<PostingTopic>>()
              .Sends<GetPostsScoresQuery, IEnumerable<PostScore>>()
              .Sends<GetCommentsScoresQuery, IEnumerable<CommentScore>>();
    }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services) 
    {
        services.AddTransient<IPostsFeed, PostsFeed>()
                .AddTransient<IPostingTopicProvider, PostingTopicProvider>()
                .AddTransient<IPostScoreProvider, ScoreProvider>()
                .AddTransient<ICommentScoresProvider, ScoreProvider>()
                .AddSingleton<IPostsRepository, PostsRepository>()
                .AddSingleton<ICommentsRepository, CommentsRepository>();
    }
}