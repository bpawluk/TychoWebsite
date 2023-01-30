using Microsoft.AspNetCore.Mvc;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/posts/{postId}/comments")]
public class CommentsController
{
    [HttpGet]
    public IEnumerable<Comment> GetComments(string postId)
    {
        return Enumerable.Empty<Comment>();
    }

    [HttpPost]
    [Route("publish")]
    public IActionResult PublishComment(string postId)
    {
        return new OkResult();
    }
}
