using TychoWebsite.Articles.Contract;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Topics.Contract;

namespace TychoWebsite.App.Contract.Mapping;

internal static class TopicsMapper
{
    public static CreateTopicCommand MapCommand(CreateArticleTopicCommand commandData)
    {
        return new(new(commandData.ArticleId, commandData.Title));
    }

    public static GetTopicsQuery MapQuery(GetPostingTopicsQuery queryData)
    {
        return new(queryData.TopicIds);
    }  
}
