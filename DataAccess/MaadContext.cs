using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public class MaadContext:IdentityDbContext
{
    public MaadContext(DbContextOptions<MaadContext> opt) : base(opt)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Post>(ConfigurePost);
        builder.Entity<Log>(ConfigureLog);

        base.OnModelCreating(builder);
    }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Log> Logs { get; set; }
    
    private void ConfigurePost(EntityTypeBuilder<Post> obj)
    {
        obj.HasKey(e=>e.Id);
    }
    
    private void ConfigureLog(EntityTypeBuilder<Log> obj)
    {
        obj.HasKey(e=>e.Id);
    }
}