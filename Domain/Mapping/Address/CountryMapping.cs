namespace Domain.Mapping.Address;

public class CountryMapping : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");
        builder.HasKey(x => x.CountryId);
        builder.Property(x => x.CountryName).HasMaxLength(255).IsRequired();
    }
}