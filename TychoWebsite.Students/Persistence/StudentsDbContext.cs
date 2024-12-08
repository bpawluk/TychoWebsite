using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using TychoWebsite.Students.Core;

namespace TychoWebsite.Students.Persistence;

internal class StudentsDbContext : TychoDbContext
{
    public DbSet<Student> Students { get; set; } = null!;

    public async Task InitDatabase()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
        Students.Add(new Student(1, [new Course(2, [6], [6, 7, 8]), new Course(4, [13], [13, 14])]));
        await SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "SQLite/TychoWebsite.Students.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}