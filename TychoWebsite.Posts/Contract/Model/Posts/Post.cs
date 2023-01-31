using TychoWebsite.Shared.Core;

namespace TychoWebsite.Posts.Contract.Model.Posts;

public record Post(
    string Id,
    string Content,
    Poster Author,
    PostScore Score,
    DateTime PublishingDate,
    List<string> Tags,
    PostingTopic? Topic = null) : IEntity;
