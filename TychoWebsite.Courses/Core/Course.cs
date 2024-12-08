namespace TychoWebsite.Courses.Core;

internal class Course(int id, string name, ICollection<Lesson> lessons, double rating, decimal price)
{
    public int Id { get; private set; } = id;

    public string Name { get; private set; } = name;

    public ICollection<Lesson> Lessons { get; private set; } = lessons;

    public double Rating { get; private set; } = rating;

    public decimal Price { get; private set; } = price;

    public Course(int id, string name, double rating, decimal price) : this(id, name, [], rating, price) { }

    public void UpdateRating(double newRating)
    {
        Rating = newRating;
    }
}