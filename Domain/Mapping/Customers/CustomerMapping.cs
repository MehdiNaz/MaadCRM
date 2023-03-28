namespace Domain.Mapping.Customers;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.CustomerId);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();

        
        builder.HasOne(x => x.Moaref).WithMany(x => x.Customers).HasForeignKey(x => x.MoarefId);
        builder.HasOne(x => x.EmailAddress).WithMany(x => x.EmaCollection).HasForeignKey(x => x.EmailId);
        builder.HasOne(x => x.PhoneNubmer).WithMany(x => x.Customers).HasForeignKey(x => x.PhoneNumberId);
        builder.HasOne(x => x.CustomersCategories).WithMany(x => x.Customers).HasForeignKey(x => x.CategoryId);
    }
}