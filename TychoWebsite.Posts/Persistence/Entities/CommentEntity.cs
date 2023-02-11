using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Posts.Persistence.Entities;

internal record CommentEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = default!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string PostId { get; init; } = default!;

    public PosterEntity Author { get; init; } = default!;

    public string Content { get; init; } = default!;

    public DateTime PublishingDate { get; init; }

    public bool IsArchived { get; init; }
}
