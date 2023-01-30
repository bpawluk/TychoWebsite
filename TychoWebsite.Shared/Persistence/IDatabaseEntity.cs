using TychoWebsite.Shared.Core;

namespace TychoWebsite.Shared.Persistence;

public interface IDatabaseEntity : IEntity
{
    bool IsArchived { get; }
}
