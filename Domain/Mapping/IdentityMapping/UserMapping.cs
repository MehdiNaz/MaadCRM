namespace Domain.Mapping.IdentityMapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
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


        builder.HasOne(x => x.City).WithMany(x => x.Users).HasForeignKey(x => x.CityId);
        builder.HasOne(x => x.Business).WithMany(x => x.Users).HasForeignKey(x => x.BusinessId);
    }
}