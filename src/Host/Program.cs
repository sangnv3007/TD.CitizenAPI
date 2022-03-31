using FluentValidation.AspNetCore;
using TD.CitizenAPI.Application;
using TD.CitizenAPI.Host.Configurations;
using TD.CitizenAPI.Host.Controllers;
using TD.CitizenAPI.Infrastructure;
using TD.CitizenAPI.Infrastructure.Common;
using Serilog;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.FileProviders;

[assembly: ApiConventionType(typeof(FSHApiConventions))]

StaticLogger.EnsureInitialized();
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

    builder.Services.AddSpaStaticFiles(c =>
    {
        c.RootPath = "ClientApp";
    });

    //Firebase
    FirebaseApp.Create(new AppOptions()
    {
        Credential = GoogleCredential.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "Configurations", "firebase_admin_sdk.json")),
    });
    //End Firebase

    var app = builder.Build();

    await app.Services.InitializeDatabasesAsync();

    app.UseInfrastructure(builder.Configuration);




    app.UseStaticFiles();
    app.UseSpaStaticFiles();
    app.UseRouting();


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");


    app.UseSpa(spa =>
    {
        // To learn more about options for serving an Angular SPA from ASP.NET Core,
        // see https://go.microsoft.com/fwlink/?linkid=864501

        spa.Options.SourcePath = "ClientApp";

       
    });




    app.MapEndpoints();
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    StaticLogger.EnsureInitialized();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}