using Microsoft.Extensions.Configuration;
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
    private IConfiguration? _config;

    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.ForwardArticlesModuleMessages()
              .ForwardPostsModuleMessages()
              .ForwardReactionsModuleMessages()
              .ForwardTopicsModuleMessages();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services)
    {
        module.AddSubmodule<ArticlesModule>(ArticlesConsumer.Consume, Configure<ArticlesModule>)
              .AddSubmodule<PostsModule>(PostsConsumer.Consume, Configure<PostsModule>)
              .AddSubmodule<ReactionsModule>(configurationDefinition: Configure<ReactionsModule>)
              .AddSubmodule<TopicsModule>(configurationDefinition: Configure<TopicsModule>);
    }

    protected override void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        _config = configuration;
    }

    private void Configure<T>(IConfigurationBuilder builder) => builder.AddConfiguration(_config!.GetSection(typeof(T).Name));
}
