using TychoWebsite.Shared.Core;

namespace TychoWebsite.Posts.Contract.Model.Comments;

public record Comment(
    string Id,
    string PostId,
    string Content,
    Poster Author,
    CommentScore Score,
    DateTime PublishingDate) : IEntity;
