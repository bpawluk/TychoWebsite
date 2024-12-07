using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using Tycho.Persistence.EFCore;
using TychoWebsite.Rating.Contract.Incoming.Requests;
using TychoWebsite.Rating.Contract.Outgoing.Events;
using TychoWebsite.Rating.Messaging.Handlers;
using TychoWebsite.Rating.Persistence;

namespace TychoWebsite.Rating;

public class RatingModule : TychoModule
{
    protected override void DefineContract(IModuleContract module) 
    {
        module.Handles<Rate, RateHandler>();
    }

    protected override void DefineEvents(IModuleEvents module) 
    {
        module.Routes<RatingChanged>()
              .Exposes();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddTychoPersistence<RatingDbContext>();
    }

    protected override async Task Startup(IServiceProvider app)
    {
        using var context = app.GetRequiredService<RatingDbContext>();
        await context.InitDatabase();
    }
}