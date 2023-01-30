using TychoWebsite.Shared.Core;

namespace TychoWebsite.Articles.Contract.Model;

public record NewArticle(
    string Id,
    string Title,
    string Lead,
    string Body,
    string Author,
    List<string> Tags) : IEntity;
