using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Articles.Persistence.Entities;

internal class ArticleEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public AuthorEntity Author { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Lead { get; set; } = null!;

    public string Body { get; set; } = null!;

    public DateTime PublishingDate { get; set; }

    public List<string> Tags { get; set; } = new List<string>();

    public bool IsPublished { get; set; }

    public bool IsArchived { get; set; }
}
