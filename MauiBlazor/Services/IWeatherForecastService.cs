using Models;

namespace MauiBlazor.Services;

internal interface IWeatherForecastService
{
    Task<WeatherForecast[]> GetWeatherForecastsAsync();
}