using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Users;

public class Role : IdentityRole<int>, IEntity<int>
{
    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    public int RoleLevel { get; set; }
    public ICollection<RolePatternDetails> rolePatternDetails { get; set; }

}

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
    }
}