using GSN.Domain;
using GSN.Infrastructure.Data;

namespace GSN.Infrastructure.Repositories;
public class WeatherForecastRepository : Repository<WeatherForecast, Guid>
{
    private readonly AppDbContext _context;

    public WeatherForecastRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
