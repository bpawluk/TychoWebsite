using Tycho.Messaging.Payload;
using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Contract;

public record CreateArticleTopicCommand : ICommand;
public record GetArticleScoreQuery : IQuery<ArticleScore>;
