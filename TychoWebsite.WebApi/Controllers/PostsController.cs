using Microsoft.AspNetCore.Mvc;
using TychoWebsite.App.Contract.Model;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/posts")]
public class PostsController
{
    private readonly IPostsService _postsService;

    public PostsController(IPostsService postsService)
    {
        _postsService = postsService;
    }

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
