namespace Application.Interfaces.Customers;

public interface IProductCustomerFavoritesListRepository
{
    Task<ICollection<ProductCustomerFavoritesList?>> GetAllProductCustomerFavoritesListsAsync();
    ValueTask<ProductCustomerFavoritesList?> GetProductCustomerFavoritesListByIdAsync(Ulid productId, Ulid customerId);
    ValueTask<ProductCustomerFavoritesList?> CreateProductCustomerFavoritesListAsync(CreateProductCustomerFavoritesListCommand request);
    ValueTask<ProductCustomerFavoritesList?> UpdateProductCustomerFavoritesListAsync(UpdateProductCustomerFavoritesListCommand request);
    ValueTask<ProductCustomerFavoritesList?> DeleteProductCustomerFavoritesListAsync(Ulid productId, Ulid customerId);
}
