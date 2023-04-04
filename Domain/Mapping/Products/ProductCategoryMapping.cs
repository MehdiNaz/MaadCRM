namespace Domain.Mapping.Products;

public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        builder.HasKey(x => x.ProductCategoryId);
        builder.Property(x => x.ParentId).IsRequired();
        builder.Property(x => x.Order).IsRequired();
        builder.Property(x => x.ProductCategoryName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Icon).HasMaxLength(255);

        builder.HasMany(x => x.Products).WithOne(x => x.ProductCategory).HasForeignKey(x => x.ProductCategoryId);


        // SelfRelation
        builder.HasOne(x => x.IdParrentNavigation).WithMany(x => x.InverseIdParrentNavigation).HasForeignKey(x => x.ParentId);
    }
}