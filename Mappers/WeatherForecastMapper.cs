using FastAPI.Models;
using FastAPI.Requests;
using FastAPI.Responses;
using FastEndpoints;

namespace FastAPI.Mappers
{
    public class WeatherForecastMapper : Mapper<WeatherForecastRequest, WeatherForecastResponse,WeatherForecast>
    {
        public override WeatherForecastResponse FromEntity(WeatherForecast e)
        {
            return new WeatherForecastResponse
            {
                Date = e.Date,
                Summary = e.Summary,
                TemperatureC  = e.TemperatureC,
                TemperatureF = e.TemperatureF
            };
        }
    }
}
