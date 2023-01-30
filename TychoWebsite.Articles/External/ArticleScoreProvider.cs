using Tycho;
using TychoWebsite.Articles.Contract;
using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Articles.Core;

namespace TychoWebsite.Articles.External;

internal class ArticleScoreProvider : IArticleScoreProvider
{
    private readonly IModule _thisModule;

    public ArticleScoreProvider(IModule thisModule)
    {
        _thisModule = thisModule;
    }

    public Task<ArticleScore> GetScore(string articleId, CancellationToken token)
    {
        return _thisModule.Execute<GetArticleScoreQuery, ArticleScore>(new(articleId), token);
    }
}
