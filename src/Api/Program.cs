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
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=database.sqlite");
        });

        services.AddScoped<IBlogRepository, BlogRepository>();
    })
    .Build();

host.Run();
