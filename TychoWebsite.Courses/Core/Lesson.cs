namespace TychoWebsite.Courses.Core;

internal class Lesson(int id, string name)
{
    public int Id { get; private set; } = id;

    public string Name { get; private set; } = name;
}