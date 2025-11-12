using CommunityToolkit.Maui;
using InventoryApp.Core.Services;
using InventoryApp.Core.ViewModels;
using Microsoft.Extensions.Logging;
using static System.Net.WebRequestMethods;

namespace InventoryApp.Gui
{
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
            //string token = "1|sgWidkWdXPZTXRy4DJo6mbuSKisjv14ogyPDTNYD744c2e06";
            string token = Preferences.Get("ApiToken", string.Empty);
            string apiBase = "https://inventory.test/api";

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DashboardViewModel>();
            builder.Services.AddSingleton<IRepository>(new RestService(token,  apiBase));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
