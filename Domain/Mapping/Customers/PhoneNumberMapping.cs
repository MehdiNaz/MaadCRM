namespace Domain.Mapping.Customers;

public class PhoneNumberMapping : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    {
        builder.ToTable("PhoneNumbers");
        builder.HasKey(x => x.PhoneNumberId);
        builder.Property(x => x.PhoneNo).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.Customer).WithMany(x => x.PhoneNubmers).HasForeignKey(x => x.CustomerId);
    }
}