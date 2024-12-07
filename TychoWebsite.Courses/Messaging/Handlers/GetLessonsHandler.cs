using Tycho.Requests;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using static TychoWebsite.Courses.Contract.Incoming.Requests.GetLessons;

namespace TychoWebsite.Courses.Messaging.Handlers;

internal class GetLessonsHandler : IRequestHandler<GetLessons, Response>
{
    public Task<Response> Handle(GetLessons requestData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}