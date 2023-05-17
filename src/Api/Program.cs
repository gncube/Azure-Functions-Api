using GSN.Application.Interfaces;
using GSN.Domain;
using GSN.Infrastructure.Data;
using GSN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddScoped<AppDbContext>(svr =>
        {
            var home = Environment.GetEnvironmentVariable("HOME") ?? "";
            var databasePath = Path.Combine(home, "database.sqlite");

            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite($"Data Source={databasePath}");
            return new AppDbContext(options.Options);
        });

        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IRepository<WeatherForecast, Guid>, WeatherForecastRepository>();
    })
    .Build();

host.Run();
