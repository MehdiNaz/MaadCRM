namespace Domain.Mapping.Products;

public class ProductsMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProductName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.IdProductCategory).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(255);
        builder.Property(x => x.Summery).HasMaxLength(255);

        builder.HasOne(x => x.ProductCategoryIdNavigation)
            .WithMany(x => x.Products)
            .HasForeignKey(d => d.IdProductCategory)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product_ProductCategory");
    }
}