namespace Domain.Mapping.Address;

public class AddressMapping : IEntityTypeConfiguration<Models.Address.Address>
{
    public void Configure(EntityTypeBuilder<Models.Address.Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(e => e.AddressId);
        builder.Property(x => x.Address1).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Address2).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CompanyName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.ZipPostalCode).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(255).IsRequired();



        builder.HasOne(x => x.Customer).WithMany(x => x.Addresses).HasForeignKey(x => x.AddressId);
        builder.HasOne(x => x.City).WithMany(x => x.Addresses).HasForeignKey(x => x.CityId);
    }
}