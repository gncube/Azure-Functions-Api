using Client.Services.Interfaces;
using GSN.Domain;
using System.Text.Json;

namespace Client.Services;

public class WeatherForecastService : IDataService<WeatherForecast, Guid>
{
    private readonly HttpClient _httpClient;

    public WeatherForecastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<WeatherForecast>> GetAllAsync(bool refreshRequired = false)
    {
        //TODO: Add Local Storage Service
        using var responseStream = await _httpClient.GetStreamAsync($"api/weatherforecast");
        using var jsonDoc = await JsonDocument.ParseAsync(responseStream);

        var weatherForecastArray = jsonDoc.RootElement.GetProperty("Value");

        var weatherForecasts = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(weatherForecastArray.GetRawText(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");

        return weatherForecasts;
    }

    public Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WeatherForecast> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<WeatherForecast> CreateAsync(WeatherForecast t)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(WeatherForecast t)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
