using TychoWebsite.Shared.Core;

namespace TychoWebsite.Posts.Contract.Model.Posts;

public record PostingTopic(string Id, string Name, IEnumerable<string> Tags) : IEntity;