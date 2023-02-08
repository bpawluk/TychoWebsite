using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Contract.Model.Posts;
using TychoWebsite.Reactions.Contract.Model;
using TychoWebsite.Topics.Contract.Model;

namespace TychoWebsite.App.Contract.Mapping;

internal static class PostsMapper
{
    public static IEnumerable<PostScore> MapToPostScore(IEnumerable<Score> response)
    {
        return response.Select(score => new PostScore(score.Id, score.Value));
    }

    public static IEnumerable<CommentScore> MapToCommentScore(IEnumerable<Score> response)
    {
        return response.Select(score => new CommentScore(score.Id, score.Value));
    }

    public static IEnumerable<PostingTopic> MapResponse(IEnumerable<Topic> response)
    {
        return response.Select(topic => new PostingTopic(topic.Id, topic.Name, topic.Tags));
    }
}
