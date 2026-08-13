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

            // Gør det muligt at bruge Blazor/Razor i MAUI
            builder.Services.AddMauiBlazorWebView();

            // Opretter HttpClient og fortæller appen,
            // hvor PixelFit API'et ligger
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri(
                        "http://pixelwebsiteapi.duckdns.org:5000/"
                    )
                });

            // Registrerer AuthService så den kan bruges
            // i vores Razor-sider via Dependency Injection
            builder.Services.AddScoped<AuthService>();

            // Udviklingsværktøjer som kun bruges under development
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();

            // Bygger og starter MAUI-applikationen
            return builder.Build();
        }
    }
}