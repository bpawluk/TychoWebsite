using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TychoWebsite.Articles.Persistence.Entities;

internal record AuthorEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = null!;

    public string Name { get; init; } = null!;
}
