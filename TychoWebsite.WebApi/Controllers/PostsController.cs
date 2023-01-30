using Microsoft.AspNetCore.Mvc;
using Tycho;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/posts")]
public class PostsController : TychoController
{
    public PostsController(IModule tychoApp) : base(tychoApp) { }

    [HttpGet]
    public IEnumerable<Post> GetPosts()
    {
        return Enumerable.Empty<Post>();
    }

    [HttpPost]
    [Route("publish")]
    public IActionResult PublishPost()
    {
        return new OkResult();
    }
}
