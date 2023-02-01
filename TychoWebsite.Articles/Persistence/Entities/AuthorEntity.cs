using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TychoWebsite.Articles.Persistence.Entities;

internal class AuthorEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;
}
