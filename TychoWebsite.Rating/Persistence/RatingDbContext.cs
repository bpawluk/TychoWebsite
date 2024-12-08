using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using TychoWebsite.Rating.Core;

namespace TychoWebsite.Rating.Persistence;

internal class RatingDbContext : TychoDbContext
{
    public DbSet<Target> Targets { get; set; } = default!;

    public async Task InitDatabase()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
        Targets.AddRange(
            new Target(1, [3, 4, 5]),
            new Target(2, [5, 5, 5]),
            new Target(3, [4, 3, 2]),
            new Target(4, [2, 5, 5]),
            new Target(5, [3, 3, 3]));
        await SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "SQLite/TychoWebsite.Rating.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}