namespace WebApi.StartupConfiguration;

public static  class LogConfiguration
{
    public static void Configuration(WebApplicationBuilder builder)
    {
        builder.Services.AddScheduler();

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(context.Configuration));

    }
}