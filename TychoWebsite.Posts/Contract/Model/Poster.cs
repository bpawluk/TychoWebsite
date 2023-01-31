using TychoWebsite.Shared.Core;

namespace TychoWebsite.Posts.Contract.Model;

public record Poster(string Id, string Name) : IEntity;