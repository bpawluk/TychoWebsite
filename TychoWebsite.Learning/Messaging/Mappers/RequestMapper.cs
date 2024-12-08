using System.Collections.Immutable;
using CoursesIn = TychoWebsite.Courses.Contract.Incoming.Requests;
using StudentsOut = TychoWebsite.Students.Contract.Outgoing.Requests;

namespace TychoWebsite.Learning.Messaging.Mappers;

internal static class RequestMapper
{
    public static CoursesIn.GetCourse MapRequest(StudentsOut.GetCourse requestData)
    {
        return new(requestData.CourseId);
    }

    public static StudentsOut.GetCourse.Response MapResponse(CoursesIn.GetCourse.Response responseData)
    {
        return new(new(
            responseData.Course.Id,
            responseData.Course.Name,
            responseData.Course.Lessons
                .Select(lesson => new StudentsOut.GetCourse.LessonData(
                    lesson.Id,
                    lesson.Name))
                .ToImmutableList()));
    }
}