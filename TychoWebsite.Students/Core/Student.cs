namespace TychoWebsite.Students.Core;

internal class Student(int id, ICollection<Course> courses)
{
    public int Id { get; private set; } = id;

    public ICollection<Course> Courses { get; private set; } = courses;

    public Student(int id) : this(id, []) { }

    public void AddCourse(Course course)
    {
        if (!Courses.Any(c => c.Id == course.Id))
        {
            Courses.Add(course);
        }
    }

    public Course GetCourse(int courseId)
    {
        return Courses.FirstOrDefault(c => c.Id == courseId)
            ?? throw new InvalidOperationException($"Course with ID {courseId} is not owned by the user");
    }
}