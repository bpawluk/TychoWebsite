using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Courses.Core;
using static TychoWebsite.Courses.Contract.Incoming.Requests.GetLessons;

namespace TychoWebsite.Courses.Messaging.Handlers;

internal class GetLessonsHandler(IUnitOfWork unitOfWork, ILogger<GetLessonsHandler> logger) : IRequestHandler<GetLessons, Response>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<GetLessonsHandler> _logger = logger;

    public async Task<Response> Handle(GetLessons requestData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");

        var course = await _unitOfWork
            .Set<Course>()
            .Include(course => course.Lessons)
            .FirstOrDefaultAsync(course => course.Id == requestData.CourseId, cancellationToken: cancellationToken);

        if (course is null)
        {
            throw new InvalidOperationException($"Failed to get lessons from a course with ID {requestData.CourseId}");
        }

        var lessons = course.Lessons
            .Select(lesson => new LessonData(lesson.Id, lesson.Name))
            .ToImmutableList();

        _logger.LogInformation("Processing finished");
        return new(lessons);
    }
}