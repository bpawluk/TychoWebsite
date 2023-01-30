using TychoWebsite.Shared.Core;

namespace TychoWebsite.Articles.Contract.Model;

public record Article(
    string Id,
    string Title,
    string Lead,
    string Body,
    Author Author,
    ArticleScore Score,
    DateTime PublishingDate,
    List<string> Tags,
    bool IsPublished) : IEntity;
