using Microsoft.Extensions.Logging;
using Tycho.Events;
using Tycho.Persistence.EFCore;
using TychoWebsite.Courses.Contract.Incoming.Events;
using TychoWebsite.Courses.Core;

namespace TychoWebsite.Courses.Messaging.Handlers;

internal class CourseRatingChangedHandler(IUnitOfWork unitOfWork, ILogger<CourseRatingChangedHandler> logger) : IEventHandler<CourseRatingChanged>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<CourseRatingChangedHandler> _logger = logger;

    public async Task Handle(CourseRatingChanged eventData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");

        var course = await _unitOfWork
            .Set<Course>()
            .FindAsync([eventData.CourseId], cancellationToken);

        if (course is null)
        {
            throw new InvalidOperationException($"Failed to update rating of a course with ID {eventData.CourseId}");
        }
        course.UpdateRating(eventData.NewValue);

        await _unitOfWork.SaveChanges(cancellationToken);
        _logger.LogInformation("Processing finished");
    }
}