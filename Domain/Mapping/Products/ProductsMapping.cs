namespace Domain.Mapping.Products;

public class ProductsMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.ProductCategoryId).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Summery).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.SecondaryPrice).IsRequired();
        builder.Property(x => x.Discount).IsRequired();
        builder.Property(x => x.DiscountPercent).IsRequired();
        builder.Property(x => x.FavoritesListId).IsRequired();
        builder.Property(x => x.Picture).IsRequired();


        //New Relations ==> OK
        // builder.HasMany(x => x.FavoritesLists).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        // builder.HasMany(x => x.ForoshOrders).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
    }
}