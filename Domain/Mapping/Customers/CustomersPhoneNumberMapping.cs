namespace Domain.Mapping.Customers;

public class CustomersPhoneNumberMapping : IEntityTypeConfiguration<CustomersPhoneNumber>
{
    public void Configure(EntityTypeBuilder<CustomersPhoneNumber> builder)
    {
        builder.ToTable("PhoneNumbers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PhoneNo).HasMaxLength(255).IsRequired();
        
        builder.Property(e => e.RowVersion)
            .IsRequired()
            .HasColumnName("rowversion")
            .IsRowVersion()
            .IsConcurrencyToken();
        
        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.PhoneNumbers)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomersPhoneNumber_Customers");
    }
}