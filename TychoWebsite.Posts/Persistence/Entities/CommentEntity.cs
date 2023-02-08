using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Posts.Persistence.Entities;

internal class CommentEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string PostId { get; set; } = null!;

    public PosterEntity Author { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime PublishingDate { get; set; }

    public bool IsArchived { get; set; }
}
