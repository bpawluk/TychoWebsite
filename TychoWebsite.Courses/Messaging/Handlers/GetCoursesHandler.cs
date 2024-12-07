using Tycho.Requests;
using TychoWebsite.Courses.Contract.Incoming.Requests;
using static TychoWebsite.Courses.Contract.Incoming.Requests.GetCourses;

namespace TychoWebsite.Courses.Messaging.Handlers;

internal class GetCoursesHandler : IRequestHandler<GetCourses, Response>
{
    public Task<Response> Handle(GetCourses requestData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}