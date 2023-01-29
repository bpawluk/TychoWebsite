using Microsoft.AspNetCore.Mvc;
using TychoWebsite.App.Contract.Model;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.WebApi.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticlesController
{
    private readonly IArticlesService _articlesService;

    public ArticlesController(IArticlesService articlesService) 
    { 
        _articlesService = articlesService;
    }

    [HttpGet]
    [Route("{articleId}")]
    public Article GetArticle(string articleId)
    {
        return new Article();
    }

    [HttpGet]
    public IEnumerable<ArticleSummary> GetArticles()
    {
        return Enumerable.Empty<ArticleSummary>();
    }

    [HttpPost]
    [Route("publish")]
    public IActionResult PublishArticle()
    {
        return new OkResult();
    }
}
