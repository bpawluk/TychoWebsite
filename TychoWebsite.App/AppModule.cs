using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.App.Contract.Consumers;
using TychoWebsite.App.Contract.Forwarders;
using TychoWebsite.Articles;
using TychoWebsite.Posts;
using TychoWebsite.Reactions;
using TychoWebsite.Topics;

namespace TychoWebsite.App;

public sealed partial class AppModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.ForwardArticlesModuleMessages();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services)
    {
        module.AddSubmodule<ArticlesModule>(ArticlesConsumer.Consume)
              .AddSubmodule<PostsModule>(PostsConsumer.Consume)
              .AddSubmodule<ReactionsModule>()
              .AddSubmodule<TopicsModule>();
    }

    protected override void RegisterServices(IServiceCollection services) { }
}
