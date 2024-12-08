using System.Collections.Immutable;
using Tycho.Requests;
using static TychoWebsite.Courses.Contract.Incoming.Requests.GetLessons;

namespace TychoWebsite.Courses.Contract.Incoming.Requests;

public record GetLessons(int CourseId) : IRequest<Response>
{
    public record Response(IImmutableList<LessonData> Lessons);

    public record LessonData(int Id, string Name);
}