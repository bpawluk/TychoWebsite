using Microsoft.AspNetCore.Mvc;

namespace TychoWebsite.Program.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Course>> GetCourses()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("{courseId}/purchase")]
    public IActionResult PurchaseCourse(int courseId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Route("{courseId}/rate")]
    public IActionResult RateCourse(int courseId, Rating rating)
    {
        throw new NotImplementedException();
    }

    public record Course(int Id, string Name);

    public record Rating(int NumberOfStars);
}
