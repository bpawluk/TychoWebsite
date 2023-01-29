using Tycho.Contract;
using TychoWebsite.App.Contract.Mapping;
using TychoWebsite.Articles.Contract;
using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Reactions;
using TychoWebsite.Reactions.Contract;
using TychoWebsite.Reactions.Contract.Model;
using TychoWebsite.Topics;
using TychoWebsite.Topics.Contract;

namespace TychoWebsite.App.Contract.Consumers;

internal static class ArticlesConsumer
{
    public static void Consume(IOutboxConsumer module)
    {
        module.Forward<CreateArticleTopicCommand, CreateTopicCommand, TopicsModule>(TopicsMapper.MapCommand);

        module.Forward<GetArticleScoreQuery, ArticleScore, GetScoreQuery, Score, ReactionsModule>
            (ReactionsMapper.MapQuery, ArticlesMapper.MapResponse);
    }
}
