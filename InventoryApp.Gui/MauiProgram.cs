using CommunityToolkit.Maui;
using InventoryApp.Core.Services;
using InventoryApp.Core.ViewModels;
using InventoryApp.Gui.Services;
using Microsoft.Extensions.Logging;
using static System.Net.WebRequestMethods;

namespace InventoryApp.Gui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Registrierung der Services über DI
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<DashboardViewModel>();

        // Preferences-Service per Interface
        builder.Services.AddSingleton<IPreferencesService, PreferenceService>();

        // RestService braucht nur noch das Interface, kein Token im Konstruktor
        builder.Services.AddSingleton<IRepository, RestService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

}
