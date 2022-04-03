using FastAPI.Mappers;
using FastAPI.Models;
using FastAPI.Requests;
using FastAPI.Responses;
using FastEndpoints;
using FastEndpoints.Swagger;

namespace FastAPI.Endpoints
{
    public class WeatherForecastsEndpoint:Endpoint<WeatherForecastRequest,WeatherForecastsResponse,WeatherForecastMapper>
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("weather/{days}");
            AllowAnonymous();
            Description(x => x.Produces<WeatherForecastResponse>(200,"applicaton/json"));
        }

        public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
        {
            Logger.LogInformation("Retriving weather for {days}", req.Days);

            var forecasts = Enumerable.Range(1, req.Days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            //var response = new WeatherForecastsResponse()
            //{
            //    Forecasts = forecasts.Select(x => new WeatherForecastResponse()
            //    {
            //        Date = x.Date,
            //        TemperatureC = x.TemperatureC,
            //        Summary = x.Summary,
            //        TemperatureF = x.TemperatureF
            //    })
            //};

            var response = new WeatherForecastsResponse()
            {
                Forecasts =  forecasts.Select(Map.FromEntity)
            };

            await SendAsync(response,cancellation: ct);
        }
    }
}
