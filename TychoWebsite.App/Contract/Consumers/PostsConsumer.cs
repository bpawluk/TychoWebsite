using Tycho.Contract;
using TychoWebsite.App.Contract.Mapping;

namespace TychoWebsite.App.Contract.Consumers;

internal static class PostsConsumer
{
    public static void Consume(IOutboxConsumer module)
    {
        module.Forward<GetPostingTopicQuery, PostingTopic, GetTopicQuery, Topic, TopicsModule>
            (TopicsMapper.MapQuery, PostsMapper.MapResponse);

        module.Forward<GetPostsScoresQuery, IEnumerable<PostScore>, GetScoresQuery, IEnumerable<Score>, ReactionsModule>
            (ReactionsMapper.MapQuery, PostsMapper.MapToPostScore);

        module.Forward<GetCommentsScoresQuery, IEnumerable<CommentScore>, GetScoresQuery, IEnumerable<Score>, ReactionsModule>
            (ReactionsMapper.MapQuery, PostsMapper.MapToCommentScore);
    }
}
