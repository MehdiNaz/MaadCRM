namespace Application.Interfaces.Products;

public interface IProductRepository
{
    ValueTask<ICollection<Product>> GetAllProductsAsync(Ulid businessId);
    ValueTask<Product?> GetProductByIdAsync(Ulid productId);
    ValueTask<Product?> ChangeStatusProductByIdAsync(Status status, Ulid productId);
    ValueTask<ICollection<Product>?> SearchByItemsAsync(string request);
    ValueTask<Product?> ChangeStateProductAsync(ChangeStateProductCommand request);
    ValueTask<Product?> CreateProductAsync(CreateProductCommand request);
    ValueTask<Product?> UpdateProductAsync(UpdateProductCommand request);
    ValueTask<Product?> DeleteProductAsync(DeleteProductCommand request);
}