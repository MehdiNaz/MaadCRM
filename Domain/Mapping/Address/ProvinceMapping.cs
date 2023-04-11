namespace Domain.Mapping.Address;

public class ProvinceMapping : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.ToTable("Provinces");
        builder.HasKey(x => x.ProvinceId);
        builder.Property(x => x.ProvinceName).HasMaxLength(255).IsRequired();

        // builder.HasOne(x => x.Country).WithMany(x => x.Provinces).HasForeignKey(x => x.CountryId);
    }
}