namespace Domain.Mapping.IdentityMapping;

public class UserLoginMapping : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("UserLogins");
        builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });
        builder.Property(x => x.LoginProvider).HasMaxLength(450).IsRequired();
        builder.Property(x => x.ProviderKey).HasMaxLength(450).IsRequired();
        builder.Property(x => x.ProviderDisplayName).HasMaxLength(500);
        builder.Property(x => x.UserId).HasMaxLength(450).IsRequired();
    }
}
