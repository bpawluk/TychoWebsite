using Tycho.Events;

namespace TychoWebsite.Courses.Contract.Incoming.Events;

public record CourseRatingChanged(int CourseId, double NewValue) : IEvent;