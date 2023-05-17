using GSN.Application.Interfaces;
using GSN.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api;

public class WeatherForecastApi
{
    private readonly ILogger _logger;
    private readonly IRepository<WeatherForecast, Guid> _repo;

    public WeatherForecastApi(ILoggerFactory loggerFactory, IRepository<WeatherForecast, Guid> repo)
    {
        _logger = loggerFactory.CreateLogger<WeatherForecastApi>();
        _repo = repo;
    }

    [Function(nameof(WeatherForecastGet))]
    public async Task<IActionResult> WeatherForecastGet(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "weatherforecast")] HttpRequestData req)
    {
        _logger.LogInformation($"{nameof(WeatherForecastGet)} ---> Getting all weatherforecasts");

        var weatherForecasts = _repo.GetAll();

        return new OkObjectResult(weatherForecasts);
    }
}
