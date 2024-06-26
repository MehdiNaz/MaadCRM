﻿namespace WebApi.StartupConfiguration;

public static class DataBaseConnectionConfiguration
{
    public static void Configure(IServiceCollection collection, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        collection.AddDbContext<MaadContext>(options =>
            // options.UseLazyLoadingProxies() // Todo: Remove comment for Lazy loading
            options.UseNpgsql(connectionString));
        collection.AddDatabaseDeveloperPageExceptionFilter();

    }
}