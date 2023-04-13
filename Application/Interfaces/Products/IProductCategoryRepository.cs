namespace Application.Interfaces.Products;

public interface IProductCategoryRepository
{
    ValueTask<ICollection<ProductCategory?>> GetAllProductCategoriesAsync();
    ValueTask<ProductCategory?> GetProductCategoryByIdAsync(Ulid productCategoryId);
    ValueTask<ProductCategory?> ChangeStatusProductCategoryByIdAsync(Status status, Ulid productCategoryId);
    ValueTask<ProductCategory?> CreateProductCategoryAsync(ProductCategory? entity);
    ValueTask<ProductCategory?> UpdateProductCategoryAsync(ProductCategory entity, Ulid productCategoryId);
    ValueTask<ProductCategory?> DeleteProductCategoryAsync(Ulid productCategoryId);
}