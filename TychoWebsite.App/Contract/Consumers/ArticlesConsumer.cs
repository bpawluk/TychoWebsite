using Tycho.Contract;
using TychoWebsite.App.Contract.Mapping;

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
