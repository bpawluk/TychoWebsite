using Microsoft.AspNetCore.Mvc;
using Tycho;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model.Posts;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/posts")]
public class PostsController : TychoController
{
    public PostsController(IModule tychoApp) : base(tychoApp) { }

    [HttpGet]
    public async Task<IEnumerable<Post>> GetPosts([FromQuery] string? topicId = null, [FromQuery] string[]? tags = null)
    {
        return await _app.Execute<GetPostsQuery, IEnumerable<Post>>(new(topicId, tags));
    }

    [HttpPost]
    public async Task<IActionResult> PublishPost(NewPost post)
    {
        await _app.Execute<PublishPostCommand>(new(post));
        return Ok();
    }
}
