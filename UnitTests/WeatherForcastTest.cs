using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Routes.Account;

namespace UnitTests;

public class WeatherForcastTest
{
    [Fact]
    public void GetWeatherForecasts_ReturnArrayOfObject()
    {
        var resultWeatherForecasts = LoginRoute.GetWeatherForecasts();

        Assert.IsType<Ok<WeatherForecast[]>>(resultWeatherForecasts);
    }
}