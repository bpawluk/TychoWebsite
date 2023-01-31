using TychoWebsite.Articles.Contract;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Topics.Contract;

namespace TychoWebsite.App.Contract.Mapping;

internal static class TopicsMapper
{
    public static CreateTopicCommand MapCommand(CreateArticleTopicCommand commandData)
    {
        return new();
    }

    public static GetTopicQuery MapQuery(GetPostingTopicsQuery queryData)
    {
        return new();
    }  
}
