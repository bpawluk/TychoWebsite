using Tycho.Messaging.Payload;
using TychoWebsite.Posts.Contract.Model;
using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Contract.Model.Posts;

namespace TychoWebsite.Posts.Contract;

public record GetPostingTopicsQuery(IEnumerable<string> TopicIds) : IQuery<IEnumerable<PostingTopic>>;
public record GetPostsScoresQuery(IEnumerable<string> PostIds) : IQuery<IEnumerable<PostScore>>;
public record GetCommentsScoresQuery(IEnumerable<string> CommentIds) : IQuery<IEnumerable<CommentScore>>;
