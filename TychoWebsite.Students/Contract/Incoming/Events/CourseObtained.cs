using Tycho.Events;

namespace TychoWebsite.Students.Contract.Incoming.Events;

public record CourseObtained(int StudentId, int CourseId) : IEvent;