using Tycho.Messaging.Payload;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Contract;

public record PublishArticleCommand(NewArticle Article) : ICommand;
public record GetArticleQuery(string ArticleId) : IQuery<Article>;
public record GetArticlesQuery() : IQuery<IEnumerable<ArticleSummary>>;
