namespace Domain.Mapping.Products;

public class ProductsMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProductName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.IdProductCategory).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Summery).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.SecondaryPrice).IsRequired();
        builder.Property(x => x.Discount).IsRequired();
        builder.Property(x => x.DiscountPercent).IsRequired();


        //New Relations ==> OK
        // builder.HasMany(x => x.FavoritesLists).WithOne(x => x.Product).HasForeignKey(x => x.Id);
        // builder.HasMany(x => x.ForoshOrders).WithOne(x => x.Product).HasForeignKey(x => x.Id);
    }
}