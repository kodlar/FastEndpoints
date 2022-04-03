using FastAPI.Requests;
using FastEndpoints;
using FluentValidation;

namespace FastAPI.Validators
{
    public class WeatherForecastRetrievalValidator : Validator<WeatherForecastRequest>
    {
        public WeatherForecastRetrievalValidator()
        {
            RuleFor(x => x.Days).GreaterThanOrEqualTo(1).WithMessage("Weather forecast day must be at least 1 ")
                                .LessThanOrEqualTo(14).WithMessage("Weather forecast day max 14 day");
        }
    }
}
