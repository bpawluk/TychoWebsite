namespace TychoWebsite.Rating.Core;

internal class Target(int id, ICollection<int> ratings)
{
    public int Id { get; private set; } = id;

    public ICollection<int> Ratings { get; private set; } = ratings;

    public double GetRating()
    {
        return Ratings.Average();
    }

    public void Rate(int numberOfStars)
    {
        Ratings.Add(numberOfStars);
    }
}