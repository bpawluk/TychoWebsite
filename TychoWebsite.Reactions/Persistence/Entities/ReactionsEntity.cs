using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Topics.Persistence.Entities;

internal record ReactionsEntity : IDatabaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = default!;
       
    public IEnumerable<string> SenderIds { get; init; } = Enumerable.Empty<string>();

    public bool IsArchived { get; init; }
}
