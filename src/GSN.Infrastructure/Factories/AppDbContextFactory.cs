using GSN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GSN.Infrastructure.Factories;
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var home = Environment.GetEnvironmentVariable("HOME") ?? "";
        var databasePath = Path.Combine(home, "database.sqlite");

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite($"Data Source={databasePath}");

        return new AppDbContext(optionsBuilder.Options);
    }
}

