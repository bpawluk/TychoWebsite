using Microsoft.AspNetCore.Mvc;
using Tycho;
using TychoWebsite.Articles.Contract;
using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticlesController : Controller
{
    private readonly IModule _tychoApp;

    public ArticlesController(IModule tychoApp)
    {
        _tychoApp = tychoApp;
    }

    [HttpGet]
    public async Task<IEnumerable<ArticleSummary>> GetArticles()
    {
        return await _tychoApp.Execute<GetArticlesQuery, IEnumerable<ArticleSummary>>(new());
    }

    [HttpGet]
    [Route("{articleId}")]
    public async Task<ActionResult<Article>> GetArticle(string articleId)
    {
        try
        {
            return await _tychoApp.Execute<GetArticleQuery, Article>(new(articleId));
        }
        catch (DocumentNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Route("publish")]
    public async Task<IActionResult> PublishArticle(NewArticle article)
    {
        await _tychoApp.Execute<PublishArticleCommand>(new(article));
        return Ok();
    }
}
