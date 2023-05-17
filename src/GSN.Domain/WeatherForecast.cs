using System.ComponentModel.DataAnnotations;

namespace GSN.Domain;
public class WeatherForecast
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
