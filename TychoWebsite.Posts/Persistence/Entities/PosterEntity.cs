using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TychoWebsite.Posts.Persistence.Entities;

internal record PosterEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = default!;

    public string Name { get; init; } = default!;
}
