namespace Domain.Mapping.IdentityMapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(450);
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
        builder.Property(x => x.PhoneNumber).HasMaxLength(50);
        

        builder.HasMany(x => x.UsersRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.UserClaims).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.UserTokens).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.UserLogins).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.City).WithMany(x => x.Users).HasForeignKey(x => x.CityId);
    }
}

