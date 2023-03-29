namespace Domain.Mapping.IdentityMapping;

public class UserClaimMapping : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaims");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).HasMaxLength(450).IsRequired();
        builder.Property(x => x.ClaimType).HasMaxLength(500);
        builder.Property(x => x.ClaimValue).HasMaxLength(500);
    }
}