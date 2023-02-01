using TychoWebsite.Shared.Core;

namespace TychoWebsite.Topics.Contract.Model;

public record Topic(string Id, string Name, IEnumerable<string> Tags) : IEntity
{
    public Topic(string id, string name) : this(id, name, Enumerable.Empty<string>()) { }
}