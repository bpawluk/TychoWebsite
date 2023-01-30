using Microsoft.AspNetCore.Mvc;
using Tycho;

namespace TychoWebsite.WebApi.Controllers;

public class TychoController : ControllerBase
{
    protected readonly IModule _app;

    public TychoController(IModule tychoApp)
    {
        _app = tychoApp;
    }
}
