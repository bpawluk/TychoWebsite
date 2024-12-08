using System.Collections.Immutable;
using Tycho.Requests;
using static TychoWebsite.Students.Contract.Incoming.Requests.GetProgress;

namespace TychoWebsite.Students.Contract.Incoming.Requests;

public record GetProgress(int StudentId) : IRequest<Response>
{
    public record Response(IImmutableList<ProgressData> Progress);

    public record ProgressData(int CourseId, double Completion);
}