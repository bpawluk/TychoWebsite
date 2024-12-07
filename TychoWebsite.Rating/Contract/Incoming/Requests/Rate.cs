using Tycho.Requests;

namespace TychoWebsite.Rating.Contract.Incoming.Requests;

public record Rate(int TargetId, int NumberOfStars) : IRequest;