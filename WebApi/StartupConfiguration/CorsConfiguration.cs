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
                            "http://localhost:3000"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
    }
}