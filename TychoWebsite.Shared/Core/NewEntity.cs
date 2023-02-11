using MongoDB.Bson;

namespace TychoWebsite.Shared.Core;

public record NewEntity : IEntity
{
    public string Id { get; protected set; } = ObjectId.GenerateNewId().ToString();
}
