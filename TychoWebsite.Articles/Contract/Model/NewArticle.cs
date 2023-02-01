using TychoWebsite.Shared.Core;

namespace TychoWebsite.Articles.Contract.Model;

public record NewArticle(
    string Id,
    Author Author,
    string Title,
    string Lead,
    string Body,
    List<string> Tags) : IEntity;
