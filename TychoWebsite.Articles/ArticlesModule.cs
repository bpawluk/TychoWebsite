using Microsoft.Extensions.DependencyInjection;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoWebsite.Articles.Contract;
using TychoWebsite.Articles.Contract.Handlers;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles;

public sealed class ArticlesModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services) 
    {
        module.Executes<PublishArticleCommand, PublishArticleCommandHandler>()
              .RespondsTo<GetArticleQuery, Article, GetArticleQueryHandler>()
              .RespondsTo<GetArticlesQuery, IEnumerable<ArticleSummary>, GetArticlesQueryHandler>();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services)
    {
        module.Sends<CreateArticleTopicCommand>()
              .Sends<GetArticleScoreQuery, ArticleScore>();
    }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services) { }
}