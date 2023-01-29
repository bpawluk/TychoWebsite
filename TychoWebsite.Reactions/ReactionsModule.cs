using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.Reactions.Contract;
using TychoWebsite.Reactions.Contract.Handlers;
using TychoWebsite.Reactions.Contract.Model;

namespace TychoWebsite.Reactions;

public sealed class ReactionsModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.Executes<AddReactionCommand, AddReactionCommandHandler>()
              .RespondsTo<GetScoreQuery, Score, GetScoreQueryHandler>();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services) { }
}