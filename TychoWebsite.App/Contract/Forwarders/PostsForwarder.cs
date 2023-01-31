using Tycho.Contract;
using TychoWebsite.Posts;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Contract.Model.Posts;

namespace TychoWebsite.App.Contract.Forwarders;

internal static class PostsForwarder
{
    public static IInboxDefinition ForwardPostsModuleMessages(this IInboxDefinition inboxDefinition)
    {
        inboxDefinition.Forwards<PublishPostCommand, PostsModule>()
                       .Forwards<GetPostsQuery, IEnumerable<Post>, PostsModule>();

        inboxDefinition.Forwards<PublishCommentCommand, PostsModule>()
                       .Forwards<GetCommentsQuery, IEnumerable<Comment>, PostsModule>();

        return inboxDefinition;
    }
}
