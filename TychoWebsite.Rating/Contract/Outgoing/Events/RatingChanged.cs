using Tycho.Events;

namespace TychoWebsite.Rating.Contract.Outgoing.Events;

public record RatingChanged(int TargetId, double NewValue) : IEvent;