using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Courses.Core;
using static TychoWebsite.Courses.Contract.Incoming.Requests.GetCourse;

namespace TychoWebsite.Courses.Messaging.Handlers;

internal class GetCourseHandler(IUnitOfWork unitOfWork, ILogger<GetCourseHandler> logger) : IRequestHandler<GetCourse, Response>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<GetCourseHandler> _logger = logger;

    public async Task<Response> Handle(GetCourse requestData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");

        var course = await _unitOfWork
            .Set<Course>()
            .Include(course => course.Lessons)
            .FirstOrDefaultAsync(course => course.Id == requestData.CourseId, cancellationToken: cancellationToken);

        if (course is null)
        {
            throw new InvalidOperationException($"Failed to find a course with ID {requestData.CourseId}");
        }

        var courseData = new CourseData(
            course.Id,
            course.Name,
            course.Lessons.Select(lesson => new LessonData(lesson.Id, lesson.Name)).ToImmutableList());

        _logger.LogInformation("Processing finished");
        return new(courseData);
    }
}