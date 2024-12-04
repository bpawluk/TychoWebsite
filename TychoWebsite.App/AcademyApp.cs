using Microsoft.Extensions.DependencyInjection;
using Tycho.Apps;

namespace TychoWebsite.App;

public class AcademyApp : TychoApp
{
    protected override void DefineContract(IAppContract app) { }

    protected override void DefineEvents(IAppEvents app) { }

    protected override void IncludeModules(IAppStructure app) { }

    protected override void RegisterServices(IServiceCollection app) { }
}