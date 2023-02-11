using TychoWebsite.Shared.Core;

namespace TychoWebsite.Posts.Contract.Model.Posts;

public record NewPost(
    Poster Author,
    string Content,
    List<string> Tags,
    string? TopicId = null) : NewEntity;
