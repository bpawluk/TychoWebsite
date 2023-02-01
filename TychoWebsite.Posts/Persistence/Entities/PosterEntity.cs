using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TychoWebsite.Posts.Persistence.Entities;

internal class PosterEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;
}
