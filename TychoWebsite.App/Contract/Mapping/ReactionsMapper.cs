using TychoWebsite.Articles.Contract;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Reactions.Contract;

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
