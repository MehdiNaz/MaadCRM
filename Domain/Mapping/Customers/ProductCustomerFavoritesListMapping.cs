namespace Domain.Mapping.Customers;

public class ProductCustomerFavoritesListMapping : IEntityTypeConfiguration<ProductCustomerFavoritesList>
{
    public void Configure(EntityTypeBuilder<ProductCustomerFavoritesList> builder)
    {
        builder.ToTable("ProductCustomerFavoritesLists");
        builder.HasKey(x => new { ProductId = x.IdProduct, CustomerId = x.IdCustomer });
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.FavoritesLists)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductCustomerFavoritesList_Customers");
        
        builder.HasOne(x => x.IdProductNavigation)
            .WithMany(x => x.FavoritesLists)
            .HasForeignKey(x => x.IdProduct)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductCustomerFavoritesList_Products");
    }
}