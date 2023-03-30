namespace DataAccess.Repositories.Customers;

public class ProductCustomerFavoritesListRepository : IProductCustomerFavoritesListRepository
{
    private readonly MaadContext _context;

    public ProductCustomerFavoritesListRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ProductCustomerFavoritesList?>> GetAllProductCustomerFavoritesListsAsync()
        => (await _context.ProductCustomerFavoritesLists!.ToListAsync()).Where(x => x.IsDeleted == Status.NotDeleted).ToList()!;


    public async ValueTask<ProductCustomerFavoritesList?> GetProductCustomerFavoritesListByIdAsync(Ulid productId, Ulid customerId)
    => await _context.ProductCustomerFavoritesLists!.FindAsync(productId, customerId);

    public async ValueTask<ProductCustomerFavoritesList?> CreateProductCustomerFavoritesListAsync(ProductCustomerFavoritesList? entity)
    {
        try
        {
            await _context.ProductCustomerFavoritesLists!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCustomerFavoritesList?> UpdateProductCustomerFavoritesListAsync(Ulid productId, Ulid customerId)
    {
        try
        {
            ProductCustomerFavoritesList? entity = new()
            {
                CustomerId = customerId,
                ProductId = productId
            };
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCustomerFavoritesList?> DeleteProductCustomerFavoritesListAsync(Ulid productId, Ulid customerId)
    {
        try
        {
            var customer = await GetProductCustomerFavoritesListByIdAsync(productId, customerId);
            customer!.IsDeleted = Status.Deleted;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}
