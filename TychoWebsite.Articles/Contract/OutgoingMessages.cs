using Tycho.Messaging.Payload;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Contract;

public record CreateArticleTopicCommand(string articleId) : ICommand;
public record GetArticleScoreQuery(string articleId) : IQuery<ArticleScore>;
