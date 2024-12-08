using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tycho.Events;
using Tycho.Persistence.EFCore;
using Tycho.Structure;
using TychoWebsite.Students.Contract.Incoming.Events;
using TychoWebsite.Students.Contract.Outgoing.Requests;
using TychoWebsite.Students.Core;

namespace TychoWebsite.Students.Messaging.Handlers;

internal class CourseObtainedHandler(IParent parent, IUnitOfWork unitOfWork, ILogger<CourseObtainedHandler> logger) : IEventHandler<CourseObtained>
{
    private readonly IParent _parent = parent;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<CourseObtainedHandler> _logger = logger;

    public async Task Handle(CourseObtained eventData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");

        var student = await _unitOfWork
            .Set<Student>()
            .Include(student => student.Courses)
            .SingleOrDefaultAsync(student => student.Id == eventData.StudentId, cancellationToken: cancellationToken);

        if (student is null)
        {
            throw new InvalidOperationException($"Failed to find a student with ID {eventData.StudentId}");
        }

        var getCourseResponse = await _parent.Execute<GetCourse, GetCourse.Response>(new(eventData.CourseId), cancellationToken);
        var newCourse = new Course(getCourseResponse.Course.Id, getCourseResponse.Course.Lessons.Select(lesson => lesson.Id).ToList());

        student.AddCourse(newCourse);
        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("Processing finished");    
    }
}