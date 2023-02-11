using TychoWebsite.Shared.Core;

namespace TychoWebsite.Posts.Contract.Model.Comments;

public record NewComment(
    string PostId,
    Poster Author,
    string Content) : NewEntity;
