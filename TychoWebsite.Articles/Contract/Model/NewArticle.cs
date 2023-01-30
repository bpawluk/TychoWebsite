using TychoWebsite.Shared.Core;

namespace TychoWebsite.Articles.Contract.Model;

public record NewArticle(
    string Id,
    string AuthorId,
    string Title,
    string Lead,
    string Body,
    List<string> Tags) : IEntity;
