using TychoWebsite.Shared.Core;

namespace TychoWebsite.Reactions.Contract.Model;

public record Score(string Id, int Value) : IEntity;
