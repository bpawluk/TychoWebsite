using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.Topics.Contract;
using TychoWebsite.Topics.Contract.Handlers;
using TychoWebsite.Topics.Contract.Model;

namespace TychoWebsite.Topics;

public sealed class TopicsModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.Executes<CreateTopicCommand, CreateTopicCommandHandler>()
              .RespondsTo<GetTopicQuery, Topic, GetTopicQueryHandler>();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services) { }
}