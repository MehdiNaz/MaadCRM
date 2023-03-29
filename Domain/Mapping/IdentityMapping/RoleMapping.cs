namespace Domain.Mapping.IdentityMapping;

public class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(450);
        builder.Property(x => x.Name).HasMaxLength(256);
        builder.Property(x => x.NormalizedName).HasMaxLength(256);
        builder.Property(x => x.ConcurrencyStamp).HasMaxLength(500);
        builder.HasMany(x => x.RoleClaims).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
        builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.UserId);
    }
}
