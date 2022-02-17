using FluentValidation.AspNetCore;
using TD.CitizenAPI.Application;
using TD.CitizenAPI.Host.Configurations;
using TD.CitizenAPI.Host.Controllers;
using TD.CitizenAPI.Infrastructure;
using TD.CitizenAPI.Infrastructure.Common.Extensions;
using Serilog;

[assembly: ApiConventionType(typeof(FSHApiConventions))]

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
Log.Logger.Refresh();
Log.Information("Server Booting Up...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddConfigurations();
    builder.Host.UseSerilog((_, config) =>
    {
        config.WriteTo.Console()
        .ReadFrom.Configuration(builder.Configuration);
    });

    builder.Services.AddControllers().AddFluentValidation();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();

    var app = builder.Build();

    await app.Services.InitializeDatabasesAsync();

    app.UseInfrastructure(builder.Configuration);
    app.MapEndpoints();
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    Log.Logger.Refresh();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Logger.Refresh();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}