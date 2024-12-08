using System.Collections.Immutable;
using Tycho.Requests;
using static TychoWebsite.Courses.Contract.Incoming.Requests.GetCourse;

namespace TychoWebsite.Courses.Contract.Incoming.Requests;

public record GetCourse(int CourseId) : IRequest<Response>
{
    public record Response(CourseData Course);

    public record CourseData(int Id, string Name, IImmutableList<LessonData> Lessons);

    public record LessonData(int Id, string Name);
}