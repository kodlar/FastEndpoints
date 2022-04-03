namespace FastAPI.Responses
{
    public class WeatherForecastsResponse
    {
        public IEnumerable<WeatherForecastResponse> Forecasts { get; set; }
    }
}
