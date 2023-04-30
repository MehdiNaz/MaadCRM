namespace Domain.Mapping.Location;

public class ProvinceMapping : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.ToTable("Provinces");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProvinceName).HasMaxLength(255).IsRequired();

        builder.HasOne(d => d.IdCountryNavigation)
            .WithMany(p => p.Provinces)
            .HasForeignKey(d => d.IdCountry)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Province_Country");
    }
}