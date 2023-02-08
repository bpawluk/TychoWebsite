using Microsoft.AspNetCore.Mvc;
using Tycho;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model.Comments;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentsController : TychoController
{
    public CommentsController(IModule tychoApp) : base(tychoApp) { }

    [HttpGet]
    public async Task<IEnumerable<Comment>> GetComments([FromQuery] string postId)
    {
        return await _app.Execute<GetCommentsQuery, IEnumerable<Comment>>(new(postId));
    }

    [HttpPost]
    public async Task <IActionResult> PublishComment(NewComment comment)
    {
        await _app.Execute<PublishCommentCommand>(new(comment));
        return new OkResult();
    }
}
