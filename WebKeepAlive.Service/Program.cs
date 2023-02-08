using Coravel;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WebKeepAlive.Core.Constants;
using WebKeepAlive.Core.Data;
using WebKeepAlive.Core.Interfaces;
using WebKeepAlive.Core.Services;
using WebKeepAlive.Service;
using WebKeepAlive.Service.Workers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        // Injecting Services

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
    .Build();

// Configuring Schedulers
host.Services.UseScheduler(scheduler =>
{
    scheduler.Schedule<KeepAliveWorker>().EverySeconds(20).PreventOverlapping("KeepAliveWorker");
});


await host.RunAsync();
