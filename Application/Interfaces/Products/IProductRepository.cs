namespace Application.Interfaces.Products;

public interface IProductRepository
{
    ValueTask<Result<ICollection<ProductResponse>>> GetAllProductsAsync(Ulid businessId);
    ValueTask<Result<ProductResponse>> GetProductByIdAsync(Ulid productId);
    ValueTask<Result<ProductResponse>> ChangeStatusProductByIdAsync(StatusType statusType, Ulid productId);
    ValueTask<Result<ICollection<ProductResponse>>> SearchByItemsAsync(string request);
    ValueTask<Result<ProductResponse>> ChangeStatusProductAsync(ChangeStateProductCommand request);
    ValueTask<Result<ProductResponse>> CreateProductAsync(CreateProductCommand request);
    ValueTask<Result<ProductResponse>> UpdateProductAsync(UpdateProductCommand request);
    ValueTask<Result<ProductResponse>> DeleteProductAsync(Ulid id);
}