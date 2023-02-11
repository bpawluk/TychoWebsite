using TychoWebsite.Shared.Core;

namespace TychoWebsite.Articles.Contract.Model;

public record NewArticle(
    Author Author,
    string Title,
    string Lead,
    string Body,
    List<string> Tags) : NewEntity;
