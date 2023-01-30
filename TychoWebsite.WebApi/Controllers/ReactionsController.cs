using Microsoft.AspNetCore.Mvc;
using Tycho;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/reactions/{subjectId}")]
public class ReactionsController : TychoController
{
    public ReactionsController(IModule tychoApp) : base(tychoApp) { }

    [HttpPost]
    [Route("add")]
    public IActionResult AddReaction(string subjectId)
    {
        return new OkResult();
    }
}
