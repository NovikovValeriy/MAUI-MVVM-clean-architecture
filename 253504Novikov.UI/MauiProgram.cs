using _253504Novikov.Application;
using _253504Novikov.Persistense;
using _253504Novikov.Persistense.Data;
using _253504Novikov.UI.Pages;
using _253504Novikov.UI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace _253504Novikov.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "_253504Novikov.UI.appsettings.json";
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();


            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            var connStr = builder.Configuration
                .GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";

            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

            builder.Services
                .AddApplication()
                .AddPersistence(options)
                .RegisterPages()
                .RegisterViewModels();

            DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services
                .AddSingleton<Garages>()
                .AddTransient<VehicleDetails>()
                .AddTransient<AddGarage>()
                .AddTransient<EditGarage>()
                .AddTransient<AddVehicle>()
                .AddTransient<EditVehicle>();

            return services;
        }

        static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddSingleton<GaragesViewModel>()
                .AddTransient<VehicleDetailsViewModel>()
                .AddTransient<AddGarageViewModel>()
                .AddTransient<EditGarageViewModel>()
                .AddTransient<AddVehicleViewModel>()
                .AddTransient<EditVehicleViewModel>();

            return services;
        }
    }
}
