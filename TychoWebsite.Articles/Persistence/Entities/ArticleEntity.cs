using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TychoWebsite.Shared.Core;

namespace TychoWebsite.Articles.Persistence.Entities;

internal class ArticleEntity : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Title { get; set; }

    public string Lead { get; set; }

    public string Body { get; set; }

    public string Author { get; set; }

    public DateTime PublishingDate { get; set; }

    public List<string> Tags { get; set; }

    public bool IsPublished { get; set; }

    public bool IsArchived { get; set; }
}
