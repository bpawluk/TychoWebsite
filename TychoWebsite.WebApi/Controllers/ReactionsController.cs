using Microsoft.AspNetCore.Mvc;
using Tycho;
using TychoWebsite.Reactions.Contract;
using TychoWebsite.Reactions.Contract.Model;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/reactions/{subjectId}")]
public class ReactionsController : TychoController
{
    public ReactionsController(IModule tychoApp) : base(tychoApp) { }

    [HttpPost]
    [Route("add")]
    public IActionResult AddReaction(string subjectId, string senderId)
    {
        _app.Execute<AddReactionCommand>(new(new(subjectId, senderId)));
        return new OkResult();
    }
}
