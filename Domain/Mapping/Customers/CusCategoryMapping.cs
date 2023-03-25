namespace Domain.Mapping.Customers;

public class CusCategoryMapping : IEntityTypeConfiguration<CustCategory>
{
    public void Configure(EntityTypeBuilder<CustCategory> builder)
    {
        builder.ToTable("CustomerCategories");
        builder.HasKey(x => x.CustCategoryId);
        builder.Property(x => x.CustomerCategoryName).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.CustomersCategories).WithMany(x => x.CustomerCategories).HasForeignKey(x => x.CategoryId);
    }
}