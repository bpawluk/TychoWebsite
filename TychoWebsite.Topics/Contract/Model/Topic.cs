using System.Collections.Generic;
using TychoWebsite.Shared.Core;

namespace TychoWebsite.Topics.Contract.Model;

public record Topic : IEntity
{
    public string Id { get; } 
    public string Name { get; } 
    public IEnumerable<string> Tags { get; } 

    public Topic(string id, string name, IEnumerable<string>? tags = null)
    {
        Id = id;
        Name = name;
        Tags = tags ?? Enumerable.Empty<string>();
    }
}