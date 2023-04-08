namespace Domain.Mapping.Address;

public class CityMapping : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");
        builder.HasKey(x => x.CityId);
        builder.Property(x => x.CityName);

        builder.HasOne(x => x.Province).WithMany(x => x.Cities).HasForeignKey(x => x.ProvinceId);
        builder.HasMany(x => x.Customers).WithOne(x => x.City).HasForeignKey(x => x.CityId);
        builder.HasMany(x => x.Addresses).WithOne(x => x.City).HasForeignKey(x => x.CityId);
    }
}