using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class DbContextFactory : IDesignTimeDbContextFactory<MaadContext>
{
    public MaadContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var dbContextBuilder = new DbContextOptionsBuilder<MaadContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        dbContextBuilder.UseNpgsql(connectionString);

        return new MaadContext(dbContextBuilder.Options);
    }
}