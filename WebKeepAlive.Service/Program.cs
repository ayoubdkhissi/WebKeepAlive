using Coravel;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WebKeepAlive.Core.Constants;
using WebKeepAlive.Core.Data;
using WebKeepAlive.Core.Interfaces;
using WebKeepAlive.Core.Services;
using WebKeepAlive.Service;
using WebKeepAlive.Service.Workers;

// Configuring logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(AppDefaults.LogDataFolder, rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateLogger();

Log.Information($"Database Path: {AppDefaults.DatabasePath}");
Log.Information($"Logs Path: {AppDefaults.LogDataFolder}");

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        // injecting DBContext
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = AppDefaults.DatabasePath
            }.ToString();
            options.UseSqlite(new SqliteConnection(connectionString));
        });

        // injecting Repositories
        services.AddScoped<IEndpointRepository, EndpointRepository>();

        // injecting Schedulers
        services.AddScheduler();
        services.AddScoped<KeepAliveWorker>();



        services.AddScoped<IRequestSender, RequestSender>();

    })
    .UseWindowsService()
    .UseSerilog()
    .Build();

// Configuring Schedulers
host.Services.UseScheduler(async scheduler =>
{
    // get the send rate then set it in every second (v2.0)
    //var repo = host.Services.CreateScope().ServiceProvider.GetRequiredService<IEndpointRepository>();
    
    scheduler.Schedule<KeepAliveWorker>().EveryFiveSeconds().PreventOverlapping("KeepAliveWorker");
});




await host.RunAsync();
