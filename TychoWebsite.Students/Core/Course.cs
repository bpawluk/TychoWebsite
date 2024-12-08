namespace TychoWebsite.Students.Core;

internal class Course(int courseId, ICollection<int> completedLessons, ICollection<int> allLessons)
{
    public int Id { get; private set; }

    public int CourseId { get; private set; } = courseId;

    public ICollection<int> CompletedLessons { get; private set; } = completedLessons;

    public ICollection<int> AllLessons { get; private set; } = allLessons;

    public Course(int courseId, ICollection<int> allLessons) : this(courseId, [], allLessons) { }

    public void CompleteLesson(int lessonId)
    {
        if (!AllLessons.Contains(lessonId))
        {
            throw new InvalidOperationException($"Lesson with ID {lessonId} is not part of the course");
        }

        if (!CompletedLessons.Contains(lessonId))
        {
            CompletedLessons.Add(lessonId);
        }
    }

    public double GetProgress()
    {
        return CompletedLessons.Count / (double)AllLessons.Count;
    }
}