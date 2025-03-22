using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
 
public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
 
    public WeatherService(IConfiguration configuration, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiKey = configuration["WeatherApi:ApiKey"];
    }
 
    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
        var response = await _httpClient.GetStringAsync(url);
 
        // Deserialize the response into a C# object
        return JsonConvert.DeserializeObject<WeatherResponse>(response);
    }
}
 
public class WeatherResponse
{
    public MainWeatherData Main { get; set; }
    public Weather[] Weather { get; set; }
    public string Name { get; set; }
}
 
public class MainWeatherData
{
    public double Temp { get; set; }
    public double Humidity { get; set; }
}
 
public class Weather
{
    public string Description { get; set; }
}
 