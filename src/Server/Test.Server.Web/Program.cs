﻿using Test.Server.Api.Data;

namespace Test.Server.Web;

public static partial class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(options: new()
        {
            Args = args,
            ContentRootPath = AppContext.BaseDirectory
        });

        AppEnvironment.Set(builder.Environment.EnvironmentName);

        builder.Configuration.AddClientConfigurations();

        // The following line (using the * in the URL), allows the emulators and mobile devices to access the app using the host IP address.
        if (AppEnvironment.IsDev() && OperatingSystem.IsWindows())
        {
            builder.WebHost.UseUrls("http://localhost:5000", "http://*:5000");
        }

        builder.ConfigureServices();

        var app = builder.Build();

        if (AppEnvironment.IsDev())
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
        }

        app.ConfiureMiddlewares();

        await app.RunAsync();
    }
}