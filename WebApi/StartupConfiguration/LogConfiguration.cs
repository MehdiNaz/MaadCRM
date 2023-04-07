namespace WebApi.StartupConfiguration;

public static  class LogConfiguration
{
    public static void Configuration(WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        
        // TODO: Enable Loging
        // builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(context.Configuration));
    }
}