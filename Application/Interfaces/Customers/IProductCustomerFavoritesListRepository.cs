namespace Application.Interfaces.Customers;

public interface IProductCustomerFavoritesListRepository
{
    Task<ICollection<ProductCustomerFavoritesList?>> GetAllProductCustomerFavoritesListsAsync();
    ValueTask<ProductCustomerFavoritesList?> GetProductCustomerFavoritesListByIdAsync(Ulid productId, Ulid customerId);
    ValueTask<ProductCustomerFavoritesList?> CreateProductCustomerFavoritesListAsync(ProductCustomerFavoritesList? entity);
    ValueTask<ProductCustomerFavoritesList?> UpdateProductCustomerFavoritesListAsync(Ulid productId, Ulid customerId);
    ValueTask<ProductCustomerFavoritesList?> DeleteProductCustomerFavoritesListAsync(Ulid productId, Ulid customerId);
}
