using Tycho.Messaging.Handlers;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Contract.Handlers;

internal class GetArticleQueryHandler : IQueryHandler<GetArticleQuery, Article>
{
    public Task<Article> Handle(GetArticleQuery queryData, CancellationToken cancellationToken)
    {
        return Task.FromResult<Article>(default!);
    }
}
