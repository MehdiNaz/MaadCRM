namespace Domain.Mapping.Address;

public class CityMapping : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CityName);

        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(d => d.IdProvinceNavigation)
            .WithMany(p => p.Cities)
            .HasForeignKey(d => d.IdProvince)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_City_Province");
    }
}