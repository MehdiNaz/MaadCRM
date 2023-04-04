﻿namespace DataAccess.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly MaadContext _context;

    public ProductRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<Product?>> GetAllProductsAsync()
        => (await _context.Products!.ToListAsync()).Where(x => x.ProductStatus == Status.Show).ToList()!;

    public async ValueTask<Product?> GetProductByIdAsync(Ulid productId)
        => await _context.Products!.FindAsync(productId);

    public async ValueTask<Product?> ChangeStateProductAsync(ProductStatus status, Ulid productId)
    {
        try
        {
            var product = await GetProductByIdAsync(productId);
            product!.PublishStatus = status;
            await _context.SaveChangesAsync();
            return product;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Product?> CreateProductAsync(Product? entity)
    {
        try
        {
            await _context.Products!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Product?> UpdateProductAsync(Product entity, Ulid productId)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Product?> DeleteProductAsync(Ulid productId)
    {
        try
        {
            var product = await GetProductByIdAsync(productId);
            product!.ProductStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return product;
        }
        catch
        {
            return null;
        }
    }
}