namespace TychoWebsite.App.Contract.Mapping;

internal static class PostsMapper
{
    public static IEnumerable<PostScore> MapToPostScore(IEnumerable<Score> response)
    {
        return Enumerable.Empty<PostScore>();
    }

    public static IEnumerable<CommentScore> MapToCommentScore(IEnumerable<Score> response)
    {
        return Enumerable.Empty<CommentScore>();
    }

    public static PostingTopic MapResponse(Topic response)
    {
        return new();
    }
}
