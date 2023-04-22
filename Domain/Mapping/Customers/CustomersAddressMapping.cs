namespace Domain.Mapping.Customers;

public class CustomersAddressMapping : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        builder.ToTable("CustomerAddresses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Address).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CodePost).HasMaxLength(255);
        builder.Property(x => x.PhoneNo).HasMaxLength(255);
        builder.Property(x => x.Description).HasMaxLength(255);
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.CustomerAddresses)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerAddresses_Customers");

    }
}