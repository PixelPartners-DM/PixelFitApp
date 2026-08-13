using Microsoft.Extensions.Logging;
using PixelFit.Service;

namespace PixelFit
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // Opretter MAUI-applikationen
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    // Registrerer skrifttypen som bruges i appen
                    fonts.AddFont(
                        "OpenSans-Regular.ttf",
                        "OpenSansRegular"
                    );
                });

            // Tilføjer Blazor WebView så Razor-sider kan bruges i MAUI
            builder.Services.AddMauiBlazorWebView();


            // HttpClient bruges til kommunikation med PixelFit API'et
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("DIN_API_ADRESSE_HER")
            });


            // Registrerer AuthService så den kan bruges
            // gennem Dependency Injection i Razor-siderne
            builder.Services.AddScoped<AuthService>();


            // Udviklingsværktøjer som kun bruges under development
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();

            // Bygger og returnerer MAUI-applikationen
            return builder.Build();
        }
    }
}