using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Core;

internal interface IArticlesRepository
{
    Task CreateArticle(NewArticle article, CancellationToken token);
    Task<Article> GetArticle(string articleId, CancellationToken token);
    Task<IEnumerable<ArticleSummary>> GetArticles(CancellationToken token);
}
