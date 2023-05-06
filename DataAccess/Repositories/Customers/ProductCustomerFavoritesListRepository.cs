namespace DataAccess.Repositories.Customers;

public class ProductCustomerFavoritesListRepository : IProductCustomerFavoritesListRepository
{
    private readonly MaadContext _context;

    public ProductCustomerFavoritesListRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ProductCustomerFavoritesList?>> GetAllProductCustomerFavoritesListsAsync()
        => await _context.ProductCustomerFavoritesLists.Where(x => x.StatusProductCustomerFavoritesList == Status.Show).ToListAsync();


    public async ValueTask<ProductCustomerFavoritesList?> GetProductCustomerFavoritesListByIdAsync(Ulid productId, Ulid customerId)
    => await _context.ProductCustomerFavoritesLists.FindAsync(productId, customerId);

    public async ValueTask<ProductCustomerFavoritesList?> CreateProductCustomerFavoritesListAsync(CreateProductCustomerFavoritesListCommand request)
    {
        try
        {
            ProductCustomerFavoritesList item = new()
            {
                IdProduct = request.ProductId,
                IdCustomer = request.CustomerId
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
            ProductCustomerFavoritesList item =
                await _context.ProductCustomerFavoritesLists.FindAsync(request.ProductId);
                item.IdProduct = request.ProductId;
            item.IdCustomer = request.CustomerId;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
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
            var customer = await _context.ProductCustomerFavoritesLists.FindAsync(productId, customerId);
            customer!.StatusProductCustomerFavoritesList = Status.Show;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}
