namespace Domain.Mapping.Customers;

public class CusCategoryMapping : IEntityTypeConfiguration<CustCategory>
{
    public void Configure(EntityTypeBuilder<CustCategory> builder)
    {
        builder.ToTable("CustomerCategories");
        builder.HasKey(x => x.CustCategoryId);
        builder.Property(x => x.CustomerCategoryName).HasMaxLength(255).IsRequired();
    }
}