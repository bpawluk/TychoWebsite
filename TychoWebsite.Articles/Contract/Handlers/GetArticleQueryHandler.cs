using Tycho.Messaging.Handlers;
using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Articles.Core;

namespace TychoWebsite.Articles.Contract.Handlers;

internal class GetArticleQueryHandler : IQueryHandler<GetArticleQuery, Article>
{
    private readonly IArticlesRepository _articlesRepository;

    public GetArticleQueryHandler(IArticlesRepository articlesRepository)
    {
        _articlesRepository = articlesRepository;
    }

    public Task<Article> Handle(GetArticleQuery queryData, CancellationToken cancellationToken)
    {
        return _articlesRepository.GetArticle(queryData.ArticleId, cancellationToken);
    }
}
