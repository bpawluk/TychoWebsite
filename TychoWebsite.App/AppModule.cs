using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.Articles;
using TychoWebsite.Posts;
using TychoWebsite.Reactions;
using TychoWebsite.Topics;

namespace TychoWebsite.App;

public sealed class AppModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) { }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services) 
    {
        module.AddSubmodule<ArticlesModule>()
              .AddSubmodule<PostsModule>()
              .AddSubmodule<ReactionsModule>()
              .AddSubmodule<TopicsModule>();
    }

    protected override void RegisterServices(IServiceCollection services) { }
}