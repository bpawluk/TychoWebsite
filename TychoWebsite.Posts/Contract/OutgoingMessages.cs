using Tycho.Messaging.Payload;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.Posts.Contract;

public record GetPostingTopicQuery : IQuery<PostingTopic>;
public record GetPostsScoresQuery : IQuery<IEnumerable<PostScore>>;

public record GetCommentsScoresQuery : IQuery<IEnumerable<CommentScore>>;
