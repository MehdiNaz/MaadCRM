namespace Domain.Mapping.Customers;

public class CustomerCategoryMapping : IEntityTypeConfiguration<CustomerCategory>
{
    public void Configure(EntityTypeBuilder<CustomerCategory> builder)
    {
        builder.ToTable("CustomerCategories");
        builder.HasKey(x => x.CustomerCategoryId);
        builder.Property(x => x.CustomerCategoryName).HasMaxLength(255).IsRequired();
    }
}