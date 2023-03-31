namespace Domain.Mapping.Products;

public class ProductsMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductName).HasMaxLength(255).IsRequired();


        //New Relations ==> OK
        builder.HasMany(x => x.FavoritesLists).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
    }
}