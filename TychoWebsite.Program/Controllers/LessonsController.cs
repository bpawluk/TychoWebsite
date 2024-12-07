using Microsoft.AspNetCore.Mvc;

namespace TychoWebsite.Program.Controllers;

[ApiController]
[Route("courses/{courseId}/lessons")]
public class LessonsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Lesson>> GetLessons(int courseId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("{lessonId}/complete")]
    public IActionResult CompleteLesson(int courseId, int lessonId)
    {
        throw new NotImplementedException();
    }

    public record Lesson(int Id, string Name);
}