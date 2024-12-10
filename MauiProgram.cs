using Amazon.CognitoIdentityProvider;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using SkiaSharp.Views.Maui.Controls.Hosting;
using sombrero.GoogleServices;
using sombrero.paginas;
using sombrero.services;
using sombrero.views;
using Syncfusion.Maui.Core.Hosting;

namespace sombrero
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .ConfigureSyncfusionCore()
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                            .UseMauiMaps();

#if ANDROID
#endif
            builder.Services.AddTransient<bachemapa>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<IGoogleAuthService, GoogleAuthService>();
            builder.Services.AddSingleton<NewPage1>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }




}