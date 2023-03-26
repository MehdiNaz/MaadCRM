namespace WebApi.StartupConfiguration;

public static class SwaggerConfiguration
{
    public static void Configure(IServiceCollection collection)
    {

        collection.AddEndpointsApiExplorer();
        collection.AddSwaggerGen();
        collection.Configure<SwaggerGeneratorOptions>(opts =>
        {
            opts.InferSecuritySchemes = true;
        });
    }
}