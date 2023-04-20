namespace Application.Interfaces.Products;

public interface IProductCategoryRepository
{
    ValueTask<ICollection<ProductCategory>> GetAllProductCategoriesAsync(Ulid businessId);
    ValueTask<ProductCategory?> GetProductCategoryByIdAsync(Ulid productCategoryId);
    ValueTask<ICollection<ProductCategory>> SearchByItemsAsync(string request);
    ValueTask<ProductCategory?> ChangeStatusProductCategoryByIdAsync(ChangeStatusProductCategoryCommand request);
    ValueTask<ProductCategory?> CreateProductCategoryAsync(CreateProductCategoryCommand request);
    ValueTask<ProductCategory?> UpdateProductCategoryAsync(UpdateProductCategoryCommand request);
    ValueTask<ProductCategory?> DeleteProductCategoryAsync(DeleteProductCategoryCommand request);
}