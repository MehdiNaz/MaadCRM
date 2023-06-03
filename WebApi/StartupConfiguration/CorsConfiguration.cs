namespace WebApi.StartupConfiguration;

public static class CorsConfiguration
{
    public static void Configure(IServiceCollection collection,string myAllowSpecificOrigins)
    {
        collection.AddCors(options =>
        {
            options.AddPolicy(name: myAllowSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins(
                            "http://192.168.43.118:3000",
                            "http://localhost:3000",
                            "https://maad-crm.vercel.app",
                            "https://app.maadcrm.ir",
                            "http://app.maadcrm.ir",
                            "http://maadcrm.ir",
                            "https://maadcrm.ir"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
    }
}