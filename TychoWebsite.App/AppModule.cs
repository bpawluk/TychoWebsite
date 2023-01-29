using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.App.Contract;
using TychoWebsite.App.Contract.Consumers;
using TychoWebsite.App.Contract.Model;
using TychoWebsite.App.Services;
using TychoWebsite.Articles;
using TychoWebsite.Posts;
using TychoWebsite.Reactions;
using TychoWebsite.Topics;

namespace TychoWebsite.App;

public sealed partial class AppModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.RespondsTo<GetServiceQuery, IService>(query => (services.GetRequiredService(query.ServiceType) as IService)!);
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services)
    {
        module.AddSubmodule<ArticlesModule>(ArticlesConsumer.Consume)
              .AddSubmodule<PostsModule>(PostsConsumer.Consume)
              .AddSubmodule<ReactionsModule>()
              .AddSubmodule<TopicsModule>();
    }

    protected override void RegisterServices(IServiceCollection services) 
    {
        services.AddTransient<IArticlesService, ArticlesService>()
                .AddTransient<ICommentsService, CommentsService>()
                .AddTransient<IPostsService, PostsService>()
                .AddTransient<IReactionsService, ReactionsService>();
    }
}
