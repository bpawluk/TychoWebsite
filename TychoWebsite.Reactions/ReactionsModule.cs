﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.Reactions.Contract;
using TychoWebsite.Reactions.Contract.Handlers;
using TychoWebsite.Reactions.Contract.Model;
using TychoWebsite.Reactions.Core;
using TychoWebsite.Shared.Extensions;
using TychoWebsite.Topics.Persistence;

namespace TychoWebsite.Reactions;

public sealed class ReactionsModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.SubscribesTo<NewReactionSubjectAvailableEvent, NewReactionSubjectAvailableEventHandler>()
              .Executes<AddReactionCommand, AddReactionCommandHandler>()
              .RespondsTo<GetScoreQuery, Score, GetScoreQueryHandler>()
              .RespondsTo<GetScoresQuery, IEnumerable<Score>, GetScoresQueryHandler>();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services, IConfiguration configuration) 
    {
        services.AddSingleton(configuration.GetSection<ReactionsRepositorySettings>()!)
                .AddSingleton<IReactionsRepository, ReactionsRepository>();
    }
}