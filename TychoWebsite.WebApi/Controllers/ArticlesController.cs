using Microsoft.AspNetCore.Mvc;
using Tycho;
using TychoWebsite.Articles.Contract;
using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticlesController : TychoController
{
    public ArticlesController(IModule tychoApp) : base(tychoApp) { }

    [HttpGet]
    [Route("{articleId}")]
    public async Task<ActionResult<Article>> GetArticle(string articleId)
    {
        try
        {
            return await _app.Execute<GetArticleQuery, Article>(new(articleId));
        }
        catch (DocumentNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IEnumerable<ArticleSummary>> GetArticles()
    {
        return await _app.Execute<GetArticlesQuery, IEnumerable<ArticleSummary>>(new());
    }

    [HttpPost]
    public async Task<IActionResult> PublishArticle(NewArticle article)
    {
        await _app.Execute<PublishArticleCommand>(new(article));
        return Ok();
    }
}
