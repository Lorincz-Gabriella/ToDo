using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ToDoMAUI.Services;
using ToDoMAUI.Services.Interfaces;
using ToDoMAUI.ViewModel;

namespace ToDoMAUI
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddHttpClient<IService,ToDoService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            return builder.Build();
        }
    }
}
