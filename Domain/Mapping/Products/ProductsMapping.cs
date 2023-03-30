namespace Domain.Mapping.Products;

public class ProductsMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductName).HasMaxLength(255).IsRequired();



        builder.HasOne(x => x.ProductCustomerFavoritesList).WithMany(x => x.Products).HasForeignKey(x => x.FavoritesListId);
    }
}