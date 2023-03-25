namespace Domain.Mapping.Customers;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.CustomerId);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(255).IsRequired();


        builder.HasOne(x => x.Business).WithMany(x => x.Customers).HasForeignKey(x => x.BusinessId);
        builder.HasOne(x => x.Moaref).WithMany(x => x.Customers).HasForeignKey(x => x.MoarefId);


        builder.HasOne(x => x.CustomersCategories).WithMany(x => x.Customers).HasForeignKey(x => x.CategoryId);
    }
}