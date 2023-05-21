using Application.Responses.Product;

namespace Application.Interfaces.Products;

public interface IProductCategoryRepository
{
    ValueTask<Result<ICollection<ProductCategoryResponse>>> GetAllProductCategoriesAsync(Ulid businessId);
    ValueTask<Result<ProductCategoryResponse>> GetProductCategoryByIdAsync(Ulid productCategoryId, Ulid businessId);
    ValueTask<Result<ICollection<ProductCategory>>> SearchByItemsAsync(string request);
    ValueTask<Result<ProductCategory>> ChangeStatusProductCategoryByIdAsync(ChangeStatusProductCategoryCommand request);
    ValueTask<Result<ProductCategoryResponse>> CreateProductCategoryAsync(CreateProductCategoryCommand request);
    ValueTask<Result<ProductCategoryResponse>> UpdateProductCategoryAsync(UpdateProductCategoryCommand request);
    ValueTask<Result<ProductCategoryResponse>> DeleteProductCategoryAsync(Ulid id);
}