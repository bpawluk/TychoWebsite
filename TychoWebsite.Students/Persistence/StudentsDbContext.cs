﻿using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;

namespace TychoWebsite.Students.Persistence;

internal class StudentsDbContext : TychoDbContext
{
    public async Task InitDatabase()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
        // add data
        await SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "TychoWebsite.X.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}