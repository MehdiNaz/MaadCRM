namespace DataAccess.Repositories.Forosh;

public class ForoshOrderRepository : IForoshOrderRepository
{
    private readonly MaadContext _context;

    public ForoshOrderRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ForoshOrder?>> GetAllForoshOrdersAsync()
        => await _context.ForoshOrders.Where(x => x.ForoshOrderStatus == Status.Show).ToListAsync();

    public async ValueTask<ForoshOrder?> GetForoshOrderByIdAsync(Ulid foroshOrderId)
        => await _context.ForoshOrders.FindAsync(foroshOrderId);

    public async ValueTask<ForoshOrder?> CreateForoshOrderAsync(ForoshOrder? entity)
    {
        try
        {
            await _context.ForoshOrders!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForoshOrder?> UpdateForoshOrderAsync(ForoshOrder entity, Ulid foroshOrderId)
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

    public async ValueTask<ForoshOrder?> DeleteForoshOrderAsync(Ulid foroshOrderId)
    {
        try
        {
            var foroshOrder = await GetForoshOrderByIdAsync(foroshOrderId);
            foroshOrder!.ForoshOrderStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return foroshOrder;
        }
        catch
        {
            return null;
        }
    }
}