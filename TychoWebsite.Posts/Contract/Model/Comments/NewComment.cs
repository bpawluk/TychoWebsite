using TychoWebsite.Shared.Core;

namespace TychoWebsite.Posts.Contract.Model.Comments;

public record NewComment(
    string Id,
    string PostId,
    Poster Author,
    string Content) : IEntity;
