namespace Application.Interfaces.Products;

public interface IProductCategoryRepository
{
    ValueTask<ICollection<ProductCategory>> GetAllProductCategoriesAsync(Ulid businessId);
    ValueTask<ProductCategory?> GetProductCategoryByIdAsync(Ulid productCategoryId);
    ValueTask<ICollection<ProductCategory>> SearchByItemsAsync(string request);
    ValueTask<ProductCategory?> ChangeStatusProductCategoryByIdAsync(Status status, Ulid productCategoryId);
    ValueTask<ProductCategory?> CreateProductCategoryAsync(ProductCategory? entity);
    ValueTask<ProductCategory?> UpdateProductCategoryAsync(ProductCategory entity);
    ValueTask<ProductCategory?> DeleteProductCategoryAsync(Ulid productCategoryId);
}