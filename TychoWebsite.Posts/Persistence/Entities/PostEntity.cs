using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Posts.Persistence.Entities;

internal class PostEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string? TopicId { get; set; }

    public PosterEntity Author { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime PublishingDate { get; set; }

    public List<string> Tags { get; set; } = new List<string>();

    public bool IsArchived { get; set; }
}
