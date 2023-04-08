using System.Reflection;

namespace WebApi.StartupConfiguration;

public static  class ServiceConfiguration
{
    public static void Configuration(IServiceCollection collection, IConfiguration configuration)
    {
        // collection.UseScheduler(scheduler =>
        // {
        //     scheduler.Schedule<ScheduleDatabaseInvocable>()
        //     .DailyAtHour(4);
        // });
        
        // collection.AddScheduler();

        collection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        collection.ConfigureApplication(configuration);
        
        collection.AddHealthChecks();
        

    }
}