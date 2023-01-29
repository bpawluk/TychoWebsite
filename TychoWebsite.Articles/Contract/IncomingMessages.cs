using Tycho.Messaging.Payload;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Contract;

public record PublishArticleCommand() : ICommand;
public record GetArticleQuery() : IQuery<Article>;
public record GetArticlesQuery() : IQuery<IEnumerable<ArticleSummary>>;
