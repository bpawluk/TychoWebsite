namespace TychoWebsite.App.Contract.Mapping;

internal static class TopicsMapper
{
    public static CreateTopicCommand MapCommand(CreateArticleTopicCommand commandData)
    {
        return new();
    }

    public static GetTopicQuery MapQuery(GetPostingTopicQuery queryData)
    {
        return new();
    }  
}
