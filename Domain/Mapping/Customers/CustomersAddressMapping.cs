namespace Domain.Mapping.Customers;

public class CustomersAddressMapping : IEntityTypeConfiguration<CustomersAddress>
{
    public void Configure(EntityTypeBuilder<CustomersAddress> builder)
    {
        builder.ToTable("CustomersAddresses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Address).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CodePost).HasMaxLength(255).IsRequired(false);
        builder.Property(x => x.PhoneNo).HasMaxLength(255).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(255).IsRequired(false);

        builder.HasMany(x => x.ForoshFactors).WithOne(x => x.CustomersAddress).HasForeignKey(x => x.CustomersAddressId);
    }
}