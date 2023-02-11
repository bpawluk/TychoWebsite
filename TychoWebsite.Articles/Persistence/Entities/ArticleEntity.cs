using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Articles.Persistence.Entities;

internal record ArticleEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = default!;

    public AuthorEntity Author { get; init; } = default!;

    public string Title { get; init; } = default!;

    public string Lead { get; init; } = default!;

    public string Body { get; init; } = default!;

    public DateTime PublishingDate { get; init; }

    public List<string> Tags { get; init; } = new List<string>();

    public bool IsPublished { get; init; }

    public bool IsArchived { get; init; }
}
