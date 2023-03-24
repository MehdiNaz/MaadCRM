namespace DataAccess;

public class MaadContext : IdentityDbContext
{
    public MaadContext(DbContextOptions<MaadContext> opt) : base(opt)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Plan?> Plans { get; set; }
    public DbSet<SanAt?> SanAts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PlanMapping());
        builder.ApplyConfiguration(new PostMapping());
        builder.ApplyConfiguration(new LogMapping());
        builder.ApplyConfiguration(new SanAtMapping());
        base.OnModelCreating(builder);
    }
}