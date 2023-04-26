﻿namespace Application.Interfaces.Products;

public interface IProductRepository
{
    ValueTask<Result<ICollection<ProductCategoryResponse>>> GetAllProductsAsync(Ulid businessId);
    ValueTask<Result<Product>> GetProductByIdAsync(Ulid productId);
    ValueTask<Result<Product>> ChangeStatusProductByIdAsync(Status status, Ulid productId);
    ValueTask<Result<ICollection<Product>>> SearchByItemsAsync(string request);
    ValueTask<Result<Product>> ChangeStatusProductAsync(ChangeStateProductCommand request);
    ValueTask<Result<Product>> CreateProductAsync(CreateProductCommand request);
    ValueTask<Result<Product>> UpdateProductAsync(UpdateProductCommand request);
    ValueTask<Result<Product>> DeleteProductAsync(Ulid id);
}