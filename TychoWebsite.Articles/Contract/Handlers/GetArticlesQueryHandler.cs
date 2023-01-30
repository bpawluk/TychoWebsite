using Tycho.Messaging.Handlers;
using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Articles.Core;

namespace TychoWebsite.Articles.Contract.Handlers;

internal class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, IEnumerable<ArticleSummary>>
{
    private readonly IArticlesRepository _articlesRepository;

    public GetArticlesQueryHandler(IArticlesRepository articlesRepository)
    {
        _articlesRepository = articlesRepository;
    }

    public Task<IEnumerable<ArticleSummary>> Handle(GetArticlesQuery queryData, CancellationToken cancellationToken)
    {
        return _articlesRepository.GetArticles(cancellationToken);
    }
}
