namespace Domain.Mapping.IdentityMapping;

public class UserTokenMapping : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens");
        builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
        builder.Property(x => x.Name).HasMaxLength(450).IsRequired();
        builder.Property(x => x.LoginProvider).HasMaxLength(450).IsRequired();
        builder.Property(x => x.UserId).HasMaxLength(450).IsRequired();
        builder.Property(x => x.Value).HasMaxLength(500);
    }
}
