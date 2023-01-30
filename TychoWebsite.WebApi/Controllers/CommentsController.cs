using Microsoft.AspNetCore.Mvc;
using Tycho;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/posts/{postId}/comments")]
public class CommentsController : TychoController
{
    public CommentsController(IModule tychoApp) : base(tychoApp) { }

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
