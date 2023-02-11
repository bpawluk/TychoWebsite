using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Posts.Persistence.Entities;

internal record PostEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = default!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string? TopicId { get; init; }

    public PosterEntity Author { get; init; } = default!;

    public string Content { get; init; } = default!;

    public DateTime PublishingDate { get; init; }

    public List<string> Tags { get; init; } = new List<string>();

    public bool IsArchived { get; init; }
}
