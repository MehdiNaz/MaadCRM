namespace MaadApi;

public static class RateLimiterConfiguration
{
    public static void Configure(IServiceCollection collection)
    {
        collection.AddRateLimiter(_ => _
            .AddFixedWindowLimiter(policyName: "fixed", options =>
            {
                options.PermitLimit = 4;
                options.Window = TimeSpan.FromSeconds(12);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 2;
            }));
    }
}