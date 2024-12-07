using Microsoft.AspNetCore.Mvc;
using Tycho.Structure;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Program.Utils;
using TychoWebsite.Students.Contract.Incoming.Requests;

namespace TychoWebsite.Program.Controllers;

[ApiController]
[Route("courses/{courseId}/lessons")]
public class LessonsController(IApp app) : ControllerBase
{
    private readonly IApp _app = app;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lesson>>> GetLessons(int courseId)
    {
        var request = new GetLessons(courseId);
        var response = await _app.Execute<GetLessons, GetLessons.Response>(request);
        return Ok(response.Lessons.Select(lesson => new Lesson(lesson.Id, lesson.Name)));
    }

    [HttpPost]
    [Route("{lessonId}/complete")]
    public async Task<IActionResult> CompleteLesson(int courseId, int lessonId)
    {
        var request = new CompleteLesson(Constants.UserId, courseId, lessonId);
        await _app.Execute(request);
        return NoContent();
    }

    public record Lesson(int Id, string Name);
}