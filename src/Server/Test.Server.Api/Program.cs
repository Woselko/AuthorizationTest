
using System;
using Hangfire.Dashboard;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.MemoryStorage;

namespace Test.Server.Api;

public static partial class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AppEnvironment.Set(builder.Environment.EnvironmentName);

        builder.Configuration.AddSharedConfigurations();

        // The following line (using the * in the URL), allows the emulators and mobile devices to access the app using the host IP address.
        if (AppEnvironment.IsDev() && OperatingSystem.IsWindows())
        {
            builder.WebHost.UseUrls("http://localhost:5118", "http://*:5118");
        }

        builder.ConfigureApiServices();
        builder.Services.AddSharedProjectServices();

        //hangfire
        GlobalConfiguration.Configuration
            .UseMemoryStorage();
        builder.Services.AddHangfire(config => config.UseMemoryStorage());
        builder.Services.AddHangfireServer();


        builder.Services.AddSingleton<SomeSingletonExample>(serviceProvider =>
        {
            var example = SomeSingletonExample.Instance;
            example.Initialize();
            return example;
        });


        var app = builder.Build();

        if (AppEnvironment.IsDev())
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
        }

        //hangfire
        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            Authorization = new[] { new DashboardAuthorizationFilter() }
        });

        RecurringJob.AddOrUpdate("JOBEXECUTING", () =>
            SomeSingletonExample.Instance.ExecuteHangfireJob(), Cron.Minutely);

        app.ConfiureMiddlewares();

        await app.RunAsync();
    }
}
