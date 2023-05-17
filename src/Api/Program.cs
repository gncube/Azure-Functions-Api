using GSN.Application.Interfaces;
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
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite("Data Source=database.sqlite");
            return new AppDbContext(options.Options);
        });

        services.AddScoped<IBlogRepository, BlogRepository>();
    })
    .Build();

host.Run();
