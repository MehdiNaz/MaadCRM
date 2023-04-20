namespace Domain.Mapping.Customers;

public class CustomersPhoneNumberMapping : IEntityTypeConfiguration<CustomersPhoneNumber>
{
    public void Configure(EntityTypeBuilder<CustomersPhoneNumber> builder)
    {
        builder.ToTable("PhoneNumbers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PhoneNo).HasMaxLength(255).IsRequired();
    }
}