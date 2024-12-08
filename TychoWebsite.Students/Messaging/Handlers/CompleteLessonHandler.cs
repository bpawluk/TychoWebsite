using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Students.Contract.Incoming.Requests;
using TychoWebsite.Students.Core;

namespace TychoWebsite.Students.Messaging.Handlers;

internal class CompleteLessonHandler(IUnitOfWork unitOfWork, ILogger<CompleteLessonHandler> logger) : IRequestHandler<CompleteLesson>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<CompleteLessonHandler> _logger = logger;

    public async Task Handle(CompleteLesson requestData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");

        var student = await _unitOfWork
            .Set<Student>()
            .Include(student => student.Courses)
            .SingleOrDefaultAsync(student => student.Id == requestData.StudentId, cancellationToken: cancellationToken);

        if (student is null)
        {
            throw new InvalidOperationException($"Failed to find a student with ID {requestData.StudentId}");
        }

        var course = student.GetCourse(requestData.CourseId);
        course.CompleteLesson(requestData.LessonId);

        await _unitOfWork.SaveChanges(cancellationToken);
        _logger.LogInformation("Processing finished");
    }
}