using Client.Services.Interfaces;
using GSN.Domain;
using Microsoft.AspNetCore.Components;

namespace Client.Pages;

public partial class FetchData
{
    [Inject]
    private IDataService<WeatherForecast, Guid>? _weatherForecastService { get; set; }

    private IEnumerable<WeatherForecast>? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await _weatherForecastService!.GetAllAsync();
    }
}
