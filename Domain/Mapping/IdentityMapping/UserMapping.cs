namespace Domain.Mapping.IdentityMapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Family).HasMaxLength(50);
        builder.Property(x => x.CodeMelli).HasMaxLength(256);
        builder.Property(x => x.Address).HasMaxLength(256);
        builder.Property(x => x.UserName).HasMaxLength(256);
        builder.Property(x => x.UserAgent).HasMaxLength(256);
        builder.Property(x => x.LastIp).HasMaxLength(256);
        builder.Property(x => x.WebSite).HasMaxLength(256);
        builder.Property(x => x.OtpPassword).HasMaxLength(256);
        builder.Property(x => x.Address).HasMaxLength(256);

        builder.Property(x => x.NormalizedUserName).HasMaxLength(256);
        builder.Property(x => x.Email).HasMaxLength(256);
        builder.Property(x => x.NormalizedEmail).HasMaxLength(256);
        builder.Property(x => x.PasswordHash).HasMaxLength(500);
        builder.Property(x => x.SecurityStamp).HasMaxLength(500);
        builder.Property(x => x.ConcurrencyStamp).HasMaxLength(500);
        builder.Property(x => x.PhoneNumber).HasMaxLength(11);

        builder.HasOne(x => x.IdBusinessNavigation)
            .WithMany(x => x.Users)
            .HasForeignKey(d => d.IdBusiness)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Business_User");
        
        builder.HasOne(x => x.IdGroupNavigation)
            .WithMany(x => x.Users)
            .HasForeignKey(d => d.IdGroup)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_UserGroup_User");
    }
}