using Microsoft.AspNetCore.Mvc;
using Tycho.Structure;
using TychoWebsite.Program.Utils;
using TychoWebsite.Students.Contract.Incoming.Requests;

namespace TychoWebsite.Program.Controllers;

[ApiController]
[Route("me")]
public class AccountsController(IApp app) : ControllerBase
{
    private readonly IApp _app = app;

    [HttpGet]
    [Route("progress")]
    public async Task<ActionResult<IEnumerable<CourseProgress>>> GetProgress()
    {
        var request = new GetProgress(Constants.UserId);
        var response = await _app.Execute<GetProgress, GetProgress.Response>(request);
        return Ok(response.Progress.Select(progress => new CourseProgress(progress.CourseId, progress.CourseName, progress.Completion)));
    }

    public record CourseProgress(int CourseId, string CourseName, double Completion);
}