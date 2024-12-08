using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using Tycho.Persistence.EFCore;
using TychoWebsite.Store.Contract.Incoming.Requests;
using TychoWebsite.Store.Contract.Outgoing.Events;
using TychoWebsite.Store.Messaging.Handlers;
using TychoWebsite.Store.Persistence;

namespace TychoWebsite.Store;

public class StoreModule : TychoModule
{
    protected override void DefineContract(IModuleContract module) 
    {
        module.Handles<AddFunds, AddFundsHandler>()
              .Handles<GetBalance, GetBalance.Response, GetBalanceHandler>()
              .Handles<PurchaseItem, PurchaseItemHandler>();
    }

    protected override void DefineEvents(IModuleEvents module) 
    {
        module.Routes<ItemPurchased>()
              .Exposes();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddTychoPersistence<StoreDbContext>();
    }

    protected override async Task Startup(IServiceProvider app)
    {
        using var context = app.GetRequiredService<StoreDbContext>();
        await context.InitDatabase();
    }
}