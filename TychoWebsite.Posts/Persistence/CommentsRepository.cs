using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Core.Ports;
using TychoWebsite.Posts.Persistence.Entities;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Posts.Persistence;

internal class CommentsRepository : RepositoryBase<NewComment, CommentEntity, Comment>, ICommentsRepository
{
    public CommentsRepository() : base(new RepositorySettings(@"mongodb://localhost:27017", "postsModule", "comments"))
    {
    }

    // TODO: Index on postId

    protected override Task<CommentEntity> MapToEntity(NewComment model, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    protected override Task<Comment> MapToModel(CommentEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
