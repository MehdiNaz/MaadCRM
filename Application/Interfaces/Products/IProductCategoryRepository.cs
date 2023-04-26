namespace Application.Interfaces.Products;

public interface IProductCategoryRepository
{
    ValueTask<Result<ICollection<ProductCategory>>> GetAllProductCategoriesAsync(Ulid businessId);
    ValueTask<Result<ProductCategory>> GetProductCategoryByIdAsync(Ulid productCategoryId);
    ValueTask<Result<ICollection<ProductCategory>>> SearchByItemsAsync(string request);
    ValueTask<Result<ProductCategory>> ChangeStatusProductCategoryByIdAsync(ChangeStatusProductCategoryCommand request);
    ValueTask<Result<ProductCategory>> CreateProductCategoryAsync(CreateProductCategoryCommand request);
    ValueTask<Result<ProductCategory>> UpdateProductCategoryAsync(UpdateProductCategoryCommand request);
    ValueTask<Result<ProductCategory>> DeleteProductCategoryAsync(DeleteProductCategoryCommand request);
}