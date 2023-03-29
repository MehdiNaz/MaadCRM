namespace Domain.Mapping.IdentityMapping;

public class RoleClaimMapping : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable("RoleClaims");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.RoleId).HasMaxLength(450).IsRequired();
        builder.Property(x => x.ClaimType).HasMaxLength(500);
        builder.Property(x => x.ClaimValue).HasMaxLength(500);
    }
}