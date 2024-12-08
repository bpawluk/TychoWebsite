using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using TychoWebsite.Store.Core;

namespace TychoWebsite.Store.Persistence;

internal class StoreDbContext : TychoDbContext
{
    public DbSet<Account> Accounts { get; set; } = default!;
    public DbSet<Item> Items { get; set; } = default!;

    public async Task InitDatabase()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
        Accounts.Add(new Account(1, 100));
        Items.AddRange(
            new Item(1, "How Git Works", 25),
            new Item(2, "C#: Getting Started", 25),
            new Item(3, "LINQ Fundamentals", 25),
            new Item(4, "ASP.NET Core Deep Dive", 50),
            new Item(5, "Introduction to SQL", 100));
        await SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "SQLite/TychoWebsite.Store.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}