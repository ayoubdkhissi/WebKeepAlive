using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebKeepAlive.Core.Constants;
using WebKeepAlive.Core.Data;
using WebKeepAlive.Core.Interfaces;
using WebKeepAlive.Core.Services;

namespace WebKeepAlive.UI;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        using(ServiceProvider serviceProvider = ConfigureServices())
        {
            var mainUi = serviceProvider.GetRequiredService<MainUI>();
            Application.Run(mainUi);
        }
        
    }


    public static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<MainUI>();


        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = AppDefaults.DatabasePath
            }.ToString();
            options.UseSqlite(new SqliteConnection(connectionString));
        });
        
        services.AddScoped<IEndpointRepository, EndpointRepository>();
        services.AddScoped<IWorkerService, WorkerService>();

        return services.BuildServiceProvider();
    }

}