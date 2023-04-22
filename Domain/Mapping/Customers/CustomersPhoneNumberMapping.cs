namespace Domain.Mapping.Customers;

public class CustomersPhoneNumberMapping : IEntityTypeConfiguration<CustomersPhoneNumber>
{
    public void Configure(EntityTypeBuilder<CustomersPhoneNumber> builder)
    {
        builder.ToTable("PhoneNumbers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PhoneNo).HasMaxLength(255).IsRequired();
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.PhoneNumbers)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomersPhoneNumber_Customers");
    }
}