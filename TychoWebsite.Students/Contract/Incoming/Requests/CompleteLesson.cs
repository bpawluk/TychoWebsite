using Tycho.Requests;

namespace TychoWebsite.Students.Contract.Incoming.Requests;

public record CompleteLesson(int StudentId, int CourseId, int LessonId) : IRequest;