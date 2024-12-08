using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using TychoWebsite.Courses.Core;

namespace TychoWebsite.Courses.Persistence;

internal class CoursesDbContext : TychoDbContext
{
    public DbSet<Course> Courses { get; set; } = null!;

    public async Task InitDatabase()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
        Courses.AddRange(
            new(1, "How Git Works", [new(1, "L1"), new(2, "L2"), new(3, "L3"), new(4, "L4"), new(5, "L5")], 4.0, 25),
            new(2, "C#: Getting Started", [new(6, "L1"), new(7, "L2"), new(8, "L3")], 5.0, 25),
            new(3, "LINQ Fundamentals", [new(9, "L1"), new(10, "L2"), new(11, "L3"), new(12, "L4")], 3.0, 25),
            new(4, "ASP.NET Core Deep Dive", [new(13, "L1"), new(14, "L2")], 4.0, 50),
            new(5, "Introduction to SQL", [new(15, "L1"), new(16, "L2"), new(17, "L3")], 3.0, 100));
        await SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "SQLite/TychoWebsite.Courses.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}