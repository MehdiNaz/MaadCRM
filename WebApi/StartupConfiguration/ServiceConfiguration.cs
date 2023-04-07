namespace WebApi.StartupConfiguration;

public static  class ServiceConfiguration
{
    public static void Configuration(IServiceCollection collection)
    {
        // collection.UseScheduler(scheduler =>
        // {
        //     scheduler.Schedule<ScheduleDatabaseInvocable>()
        //     .DailyAtHour(4);
        // });
        
        // collection.AddScheduler();

        // collection.AddApplication();

        collection.AddHealthChecks();
        

    }
}