using Microsoft.AspNetCore.Mvc;
using Tycho.Structure;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Program.Utils;
using TychoWebsite.Rating.Contract.Incoming.Requests;
using TychoWebsite.Store.Contract.Incoming.Requests;

namespace TychoWebsite.Program.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController(IApp app) : ControllerBase
{
    private readonly IApp _app = app;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        var request = new GetCourses();
        var response = await _app.Execute<GetCourses, GetCourses.Response>(request);
        return Ok(response.Courses.Select(course => new Course(course.Id, course.Name)));
    }

    [HttpPost]
    [Route("{courseId}/purchase")]
    public async Task<IActionResult> PurchaseCourse(int courseId)
    {
        var request = new PurchaseItem(Constants.UserId, courseId);
        await _app.Execute(request);
        return NoContent();
    }
    
    [HttpPost]
    [Route("{courseId}/rate")]
    public async Task<IActionResult> RateCourse(int courseId, Rating rating)
    {
        var request = new Rate(courseId, rating.NumberOfStars);
        await _app.Execute(request);
        return NoContent();
    }

    public record Course(int Id, string Name);

    public record Rating(int NumberOfStars);
}