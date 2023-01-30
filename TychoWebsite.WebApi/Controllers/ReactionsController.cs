using Microsoft.AspNetCore.Mvc;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/reactions/{subjectId}")]
public class ReactionsController
{
    [HttpPost]
    [Route("add")]
    public IActionResult AddReaction(string subjectId)
    {
        return new OkResult();
    }
}
