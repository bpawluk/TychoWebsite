using Microsoft.AspNetCore.Mvc;
using TychoWebsite.App.Contract.Model;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/reactions/{subjectId}")]
public class ReactionsController
{
    private readonly IReactionsService _reactionsService;

    public ReactionsController(IReactionsService reactionsService)
    {
        _reactionsService = reactionsService;
    }

    [HttpPost]
    [Route("add")]
    public IActionResult AddReaction(string subjectId)
    {
        return new OkResult();
    }
}
