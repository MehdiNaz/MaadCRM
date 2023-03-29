namespace Domain.Mapping.IdentityMapping;

public class UserRoleMapping : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
        builder.HasKey(x => new { x.RoleId, x.UserId });
        builder.Property(x => x.RoleId).HasMaxLength(450);
        builder.Property(x => x.UserId).HasMaxLength(450);
    }
}
