using Tycho.Requests;
using TychoWebsite.Students.Contract.Incoming.Requests;

namespace TychoWebsite.Students.Messaging.Handlers;

internal class CompleteLessonHandler : IRequestHandler<CompleteLesson>
{
    public Task Handle(CompleteLesson requestData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}