namespace DataAccess.Repositories.Forosh;

public class ForoshOrderRepository : IForoshOrderRepository
{
    private readonly MaadContext _context;

    public ForoshOrderRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ForooshOrder?>> GetAllForoshOrdersAsync()
        => await _context.ForoshOrders.Where(x => x.StatusForooshOrder == Status.Show).ToListAsync();

    public async ValueTask<ForooshOrder?> GetForoshOrderByIdAsync(Ulid foroshOrderId)
        => await _context.ForoshOrders.SingleOrDefaultAsync(x => x.Id == foroshOrderId && x.StatusForooshOrder == Status.Show);

    public async ValueTask<ForooshOrder?> ChangeStatusForoshOrderByIdAsync(ChangeStatusForoshOrderCommand request)
    {
        try
        {
            var item = await _context.ForoshOrders!.FindAsync(request.ForoshOrderId);
            if (item is null) return null;
            item.StatusForooshOrder = request.ForoshOrderStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForooshOrder?> CreateForoshOrderAsync(CreateForoshOrderCommand request)
    {
        try
        {
            // TODO: add Id Factor
            ForooshOrder item = new()
            {
                Price = request.Price,
                PriceShipping = request.ShippingPrice,
                PriceTotal = request.PriceTotal,
                PriceDiscount = request.DiscountPrice,
                IdProduct = request.ProductId,
                IdForooshFactor = default
            };
            await _context.ForoshOrders!.AddAsync(item!);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForooshOrder?> UpdateForoshOrderAsync(UpdateForoshOrderCommand request)
    {
        try
        {
            // TODO: add Id Factor
            ForooshOrder item = await _context.ForoshOrders.FindAsync(request.Id);
            item.Price = request.Price;
            item.PriceShipping = request.ShippingPrice;
            item.PriceTotal = request.PriceTotal;
            item.PriceDiscount = request.DiscountPrice;
            item.IdForooshFactor = default;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForooshOrder?> DeleteForoshOrderAsync(Ulid id)
    {
        try
        {
            var foroshOrder = await _context.ForoshOrders.FindAsync(id);
            foroshOrder!.StatusForooshOrder = Status.Deleted;
            await _context.SaveChangesAsync();
            return foroshOrder;
        }
        catch
        {
            return null;
        }
    }
}