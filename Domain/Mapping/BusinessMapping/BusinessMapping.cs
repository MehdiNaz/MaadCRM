namespace Domain.Mapping.BusinessMapping;

public class BusinessMapping : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.ToTable("Businesses");
        builder.HasKey(x => x.BusinessId);
        builder.Property(x => x.BusinessName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Url).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Hosts).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CompanyName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CompanyAddress).HasMaxLength(255).IsRequired();
    }
}