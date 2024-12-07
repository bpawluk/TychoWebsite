using Microsoft.AspNetCore.Mvc;

namespace TychoWebsite.Program.Controllers;

[ApiController]
[Route("me")]
public class AccountsController : ControllerBase
{
    [HttpGet]
    [Route("progress")]
    public ActionResult<IEnumerable<CourseProgress>> GetProgress()
    {
        throw new NotImplementedException();
    }

    public record CourseProgress(int CourseId, string CourseName, double Completion);
}