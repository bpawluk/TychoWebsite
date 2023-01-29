using Tycho.Messaging.Payload;
using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.Posts.Contract;

public record PublishPostCommand() : ICommand;
public record GetPostsQuery() : IQuery<IEnumerable<Post>>;

public record PublishCommentCommand() : ICommand;
public record GetCommentsQuery() : IQuery<IEnumerable<Comment>>;

