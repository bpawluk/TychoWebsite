using System.Collections.Immutable;
using Tycho.Requests;
using static TychoWebsite.Students.Contract.Outgoing.Requests.GetCourse;

namespace TychoWebsite.Students.Contract.Outgoing.Requests;

public record GetCourse(int CourseId) : IRequest<Response>
{
    public record Response(CourseData Course);

    public record CourseData(int Id, string Name, IImmutableList<LessonData> Lessons);

    public record LessonData(int Id, string Name);
}