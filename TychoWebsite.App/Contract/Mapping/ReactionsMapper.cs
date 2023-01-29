namespace TychoWebsite.App.Contract.Mapping;

internal class ReactionsMapper
{
    public static GetScoreQuery MapQuery(GetArticleScoreQuery queryData)
    {
        return new();
    }

    public static GetScoresQuery MapQuery(GetCommentsScoresQuery queryData)
    {
        return new();
    }

    public static GetScoresQuery MapQuery(GetPostsScoresQuery queryData)
    {
        return new();
    }
}
