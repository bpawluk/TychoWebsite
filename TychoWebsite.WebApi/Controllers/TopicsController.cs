using Microsoft.AspNetCore.Mvc;
using Tycho;
using TychoWebsite.Topics.Contract;
using TychoWebsite.Topics.Contract.Model;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/topics")]
public class TopicsController : TychoController
{
    public TopicsController(IModule tychoApp) : base(tychoApp) { }

    [HttpPost]
    public async Task<IActionResult> CreateTopic(Topic topic)
    {
        await _app.Execute<CreateTopicCommand>(new(topic));
        return new OkResult();
    }
}
