using Tycho.Contract;
using TychoWebsite.App.Contract.Mapping;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Contract.Model.Posts;
using TychoWebsite.Reactions;
using TychoWebsite.Reactions.Contract;
using TychoWebsite.Reactions.Contract.Model;
using TychoWebsite.Topics;
using TychoWebsite.Topics.Contract;
using TychoWebsite.Topics.Contract.Model;

namespace TychoWebsite.App.Contract.Consumers;

internal static class PostsConsumer
{
    public static void Consume(IOutboxConsumer module)
    {
        module.PassOn<PostPublishedEvent, NewReactionSubjectAvailableEvent, ReactionsModule>(ReactionsMapper.MapEvent);

        module.Forward<GetPostingTopicsQuery, IEnumerable<PostingTopic>, GetTopicsQuery, IEnumerable<Topic>, TopicsModule>
            (TopicsMapper.MapQuery, PostsMapper.MapResponse);

        module.Forward<GetPostsScoresQuery, IEnumerable<PostScore>, GetScoresQuery, IEnumerable<Score>, ReactionsModule>
            (ReactionsMapper.MapQuery, PostsMapper.MapToPostScore);

        module.Forward<GetCommentsScoresQuery, IEnumerable<CommentScore>, GetScoresQuery, IEnumerable<Score>, ReactionsModule>
            (ReactionsMapper.MapQuery, PostsMapper.MapToCommentScore);
    }
}
