using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Topics.Persistence.Entities;

internal class TopicEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;
        
    public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();

    public bool IsArchived { get; set; }
}
