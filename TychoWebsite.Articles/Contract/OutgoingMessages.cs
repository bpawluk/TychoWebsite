using Tycho.Messaging.Payload;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Contract;

public record CreateArticleTopicCommand(string ArticleId, string Title) : ICommand;
public record GetArticleScoreQuery(string ArticleId) : IQuery<ArticleScore>;
