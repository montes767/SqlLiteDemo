using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SqlLiteDemo.Abstractions;
using SqlLiteDemo.MVVM.Models;
using SqlLiteDemo.Repositories;

namespace SqlLiteDemo
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IBaseRepository<Customer>, BaseRepository<Customer>>(); 
            builder.Services.AddSingleton<IBaseRepository<Order>, BaseRepository<Order>>();
            builder.Services.AddSingleton<IBaseRepository<Passport>, BaseRepository<Passport>>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
