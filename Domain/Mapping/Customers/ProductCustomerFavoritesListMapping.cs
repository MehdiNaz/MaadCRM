namespace Domain.Mapping.Customers;

public class ProductCustomerFavoritesListMapping : IEntityTypeConfiguration<ProductCustomerFavoritesList>
{
    public void Configure(EntityTypeBuilder<ProductCustomerFavoritesList> builder)
    {
        builder.ToTable("ProductCustomerFavoritesLists");
        builder.HasKey(x => new { x.ProductId, x.CustomerId });
    }
}