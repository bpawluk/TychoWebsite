using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using TychoWebsite.Courses.Core;
using static TychoWebsite.Courses.Contract.Incoming.Requests.GetCourses;

namespace TychoWebsite.Courses.Messaging.Handlers;

internal class GetCoursesHandler(IUnitOfWork unitOfWork, ILogger<GetCoursesHandler> logger) : IRequestHandler<GetCourses, Response>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<GetCoursesHandler> _logger = logger;

    public async Task<Response> Handle(GetCourses requestData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");

        var courses = await _unitOfWork
            .Set<Course>()
            .Select(course => new CourseData(
                course.Id,
                course.Name,
                course.Lessons.Count,
                course.Rating,
                course.Price))
            .ToListAsync(cancellationToken);

        _logger.LogInformation("Processing finished");
        return new(courses.ToImmutableList());
    }
}