using TychoWebsite.Shared.Core;

namespace TychoWebsite.Posts.Contract.Model.Posts;

public record NewPost(
    string Id,
    string AuthorId,
    string Content,
    List<string> Tags,
    string? TopicId = null) : IEntity;
