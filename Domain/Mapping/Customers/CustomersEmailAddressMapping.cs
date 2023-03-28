namespace Domain.Mapping.Customers;

public class CustomersEmailAddressMapping : IEntityTypeConfiguration<CustomersEmailAddress>
{
    public void Configure(EntityTypeBuilder<CustomersEmailAddress> builder)
    {
        builder.ToTable("EmailAddresses");
        builder.HasKey(x => x.CustomersEmailAddressId);
        builder.Property(x => x.CustomersEmailAddrs).HasMaxLength(255).IsRequired();
    }
}