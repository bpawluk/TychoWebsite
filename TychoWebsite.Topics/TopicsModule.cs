using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.Topics.Contract;
using TychoWebsite.Topics.Contract.Handlers;
using TychoWebsite.Topics.Contract.Model;
using TychoWebsite.Topics.Core;
using TychoWebsite.Topics.Persistence;

namespace TychoWebsite.Topics;

public sealed class TopicsModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.Executes<CreateTopicCommand, CreateTopicCommandHandler>()
              .RespondsTo<GetTopicQuery, Topic, GetTopicQueryHandler>()
              .RespondsTo<GetTopicsQuery, IEnumerable<Topic>, GetTopicsQueryHandler>();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services, IConfiguration configuration) 
    {
        services.AddSingleton<ITopicsRepository, TopicsRepository>();
    }
}