using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
 
[Route("api/[controller]")]
[ApiController]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherService _weatherService;
 
    public WeatherForecastController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }
 
    [HttpGet("{city}")]
    public async Task<ActionResult<WeatherResponse>> GetWeather(string city)
    {
        var weather = await _weatherService.GetWeatherAsync(city);
 
        if (weather == null)
        {
            return NotFound(new { message = "City not found or API error." });
        }
 
        return Ok(weather);
    }
}