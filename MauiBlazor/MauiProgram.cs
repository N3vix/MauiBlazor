using MauiBlazor.Services;
using Microsoft.Extensions.Logging;

namespace MauiBlazor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IAuthorisationService, AuthorisationService>();
            builder.Services.AddSingleton<IServersGateway, ServersGateway>();
            builder.Services.AddSingleton<IChannelsGateway, ChannelsGateway>();
            builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

            return builder.Build();
        }
    }
}
