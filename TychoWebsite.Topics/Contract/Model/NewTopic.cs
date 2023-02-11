using TychoWebsite.Shared.Core;

namespace TychoWebsite.Topics.Contract.Model;

public record NewTopic : NewEntity
{
    public string Name { get; init; } = default!;
    public IEnumerable<string> Tags { get; init; } = Enumerable.Empty<string>();

    public NewTopic() { }

    public NewTopic(string name, IEnumerable<string>? tags = null)
    {
        Name = name;
        Tags = tags ?? Tags;
    }

    public NewTopic(string id, string name, IEnumerable<string>? tags = null) : this(name, tags)
    {
        Id = id;
    }
}
