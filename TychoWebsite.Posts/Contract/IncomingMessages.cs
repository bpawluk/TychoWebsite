using Tycho.Messaging.Payload;
using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Contract.Model.Posts;

namespace TychoWebsite.Posts.Contract;

public record PublishPostCommand(NewPost Post) : ICommand;
public record GetPostsQuery(string? TopicId, IEnumerable<string>? Tags) : IQuery<IEnumerable<Post>>;

public record PublishCommentCommand() : ICommand;
public record GetCommentsQuery() : IQuery<IEnumerable<Comment>>;

