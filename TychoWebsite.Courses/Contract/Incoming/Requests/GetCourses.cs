using System.Collections.Immutable;
using Tycho.Requests;
using static TychoWebsite.Courses.Contract.Incoming.Requests.GetCourses;

namespace TychoWebsite.Courses.Contract.Incoming.Requests;

public record GetCourses : IRequest<Response>
{
    public record Response(IImmutableList<Course> Courses);

    public record Course(Guid Id, string Name, int NumberOfLessons, double Rating);
}