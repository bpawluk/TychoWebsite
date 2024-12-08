using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Students.Contract.Incoming.Requests;
using TychoWebsite.Students.Core;
using static TychoWebsite.Students.Contract.Incoming.Requests.GetProgress;

namespace TychoWebsite.Students.Messaging.Handlers;

internal class GetProgressHandler(IUnitOfWork unitOfWork, ILogger<GetProgressHandler> logger) : IRequestHandler<GetProgress, Response>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<GetProgressHandler> _logger = logger;

    public async Task<Response> Handle(GetProgress requestData, CancellationToken cancellationToken)
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

        var progress = student.Courses
            .Select(course => new ProgressData(
                course.CourseId,
                course.GetProgress()))
            .ToImmutableList();

        _logger.LogInformation("Processing finished");
        return new(progress);
    }
}