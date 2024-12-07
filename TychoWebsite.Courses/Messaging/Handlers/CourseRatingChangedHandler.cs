using Tycho.Events;
using TychoWebsite.Courses.Contract.Incoming.Events;

namespace TychoWebsite.Courses.Messaging.Handlers;

internal class CourseRatingChangedHandler : IEventHandler<CourseRatingChanged>
{
    public Task Handle(CourseRatingChanged eventData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}