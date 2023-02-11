using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Topics.Persistence.Entities;

internal record TopicEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = default!;

    public string Name { get; init; } = default!;
        
    public IEnumerable<string> Tags { get; init; } = Enumerable.Empty<string>();

    public bool IsArchived { get; init; }
}
