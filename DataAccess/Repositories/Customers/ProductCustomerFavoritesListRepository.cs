namespace DataAccess.Repositories.Customers;

public class ProductCustomerFavoritesListRepository : IProductCustomerFavoritesListRepository
{
    private readonly MaadContext _context;

    public ProductCustomerFavoritesListRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ProductCustomerFavoritesList?>> GetAllProductCustomerFavoritesListsAsync()
        => await _context.ProductCustomerFavoritesLists.Where(x => x.ProductCustomerFavoritesListStatus == Status.Show).ToListAsync();


    public async ValueTask<ProductCustomerFavoritesList?> GetProductCustomerFavoritesListByIdAsync(Ulid productId, Ulid customerId)
    => await _context.ProductCustomerFavoritesLists.FindAsync(productId, customerId);

    public async ValueTask<ProductCustomerFavoritesList?> CreateProductCustomerFavoritesListAsync(CreateProductCustomerFavoritesListCommand request)
    {
        try
        {
            ProductCustomerFavoritesList item = new()
            {
                ProductId = request.ProductId,
                CustomerId = request.CustomerId
            };
            await _context.ProductCustomerFavoritesLists!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCustomerFavoritesList> UpdateProductCustomerFavoritesListAsync(UpdateProductCustomerFavoritesListCommand request)
    {
        try
        {
            ProductCustomerFavoritesList item = new()
            {
                ProductId = request.ProductId,
                CustomerId = request.CustomerId
            };
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCustomerFavoritesList?> DeleteProductCustomerFavoritesListAsync(DeleteProductCustomerFavoritesListCommand request)
    {
        try
        {
            var customer = await GetProductCustomerFavoritesListByIdAsync(request.ProductId, request.CustomerId);
            customer!.ProductCustomerFavoritesListStatus = Status.Show;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}
