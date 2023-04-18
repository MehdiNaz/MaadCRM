namespace Application.Interfaces.Products;

public interface IProductRepository
{
    ValueTask<ICollection<Product>> GetAllProductsAsync(Ulid businessId);
    ValueTask<Product?> GetProductByIdAsync(Ulid productId);
    ValueTask<Product?> ChangeStatusProductByIdAsync(Status status, Ulid productId);
    ValueTask<ICollection<Product>?> SearchByItemsAsync(string request);
    ValueTask<Product?> ChangeStateProductAsync(ProductStatus status, Ulid productId);
    ValueTask<Product?> CreateProductAsync(Product? entity);
    ValueTask<Product?> UpdateProductAsync(Product entity, Ulid productId);
    ValueTask<Product?> DeleteProductAsync(Ulid productId);
}