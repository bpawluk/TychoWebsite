using TychoWebsite.Shared.Core;

namespace TychoWebsite.Articles.Contract.Model;

public record Author(string Id, string Name) : IEntity;
