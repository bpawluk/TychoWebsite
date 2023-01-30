using Tycho.Contract;
using TychoWebsite.Articles;
using TychoWebsite.Articles.Contract;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.App.Contract.Forwarders;

internal static class ArticlesForwarder
{
    public static IInboxDefinition ForwardArticlesModuleMessages(this IInboxDefinition inboxDefinition)
    {
        return inboxDefinition.Forwards<PublishArticleCommand, ArticlesModule>()
                              .Forwards<GetArticleQuery, Article, ArticlesModule>()
                              .Forwards<GetArticlesQuery, IEnumerable<ArticleSummary>, ArticlesModule>();
    }
}
