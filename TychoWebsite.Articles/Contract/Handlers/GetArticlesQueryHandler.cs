using Tycho.Messaging.Handlers;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Contract.Handlers;

internal class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, IEnumerable<ArticleSummary>>
{
    public Task<IEnumerable<ArticleSummary>> Handle(GetArticlesQuery queryData, CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Empty<ArticleSummary>());
    }
}
