using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Core;

internal interface IArticleScoreProvider
{
    Task<ArticleScore> GetScore(string articleId, CancellationToken token);
}
