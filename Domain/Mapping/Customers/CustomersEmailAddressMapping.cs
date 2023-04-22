namespace Domain.Mapping.Customers;

public class CustomersEmailAddressMapping : IEntityTypeConfiguration<CustomersEmailAddress>
{
    public void Configure(EntityTypeBuilder<CustomersEmailAddress> builder)
    {
        builder.ToTable("EmailAddresses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CustomerEmailAddress).HasMaxLength(255).IsRequired();
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.EmailAddresses)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomersEmailAddress_Customers");
    }
}