using Tycho.Events;
using TychoWebsite.Students.Contract.Incoming.Events;

namespace TychoWebsite.Students.Messaging.Handlers;

internal class CourseObtainedHandler : IEventHandler<CourseObtained>
{
    public Task Handle(CourseObtained eventData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}