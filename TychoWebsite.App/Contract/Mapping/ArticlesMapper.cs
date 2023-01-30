using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Reactions.Contract.Model;

namespace TychoWebsite.App.Contract.Mapping;

internal static class ArticlesMapper
{
    public static ArticleScore MapResponse(Score response)
    {
        return new(int.MaxValue);
    }
}
