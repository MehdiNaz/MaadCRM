namespace DataAccess.Repositories.Customers.Foroosh;

public class ForooshOrderRepository : IForooshOrderRepository
{
    private readonly MaadContext _context;

    public ForooshOrderRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ForooshOrder?>> GetAllForooshOrdersAsync()
        => await _context.ForooshOrders.Where(x => x.StatusTypeForooshOrder == StatusType.Show).ToListAsync();

    public async ValueTask<ForooshOrder?> GetForooshOrderByIdAsync(Ulid ForooshOrderId)
        => await _context.ForooshOrders.SingleOrDefaultAsync(x => x.Id == ForooshOrderId && x.StatusTypeForooshOrder == StatusType.Show);

    public async ValueTask<ForooshOrder?> ChangeStatusForooshOrderByIdAsync(ChangeStatusForooshOrderCommand request)
    {
        try
        {
            var item = await _context.ForooshOrders!.FindAsync(request.ForooshOrderId);
            if (item is null) return null;
            item.StatusTypeForooshOrder = request.ForooshOrderStatusType;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForooshOrder?> CreateForooshOrderAsync(CreateForooshOrderCommand request)
    {
        try
        {
            ForooshOrder item = new()
            {
                Price = request.Price,
                PriceShipping = request.ShippingPrice,
                PriceTotal = request.PriceTotal,
                PriceDiscount = request.DiscountPrice,
                IdProduct = request.ProductId,
                IdForooshFactor = request.FactorId
            };
            await _context.ForooshOrders!.AddAsync(item!);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForooshOrder?> UpdateForooshOrderAsync(UpdateForooshOrderCommand request)
    {
        try
        {
            // TODO: add Id Factor
            ForooshOrder item = await _context.ForooshOrders.FindAsync(request.Id);
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

    public async ValueTask<ForooshOrder?> DeleteForooshOrderAsync(Ulid id)
    {
        try
        {
            var ForooshOrder = await _context.ForooshOrders.FindAsync(id);
            ForooshOrder!.StatusTypeForooshOrder = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return ForooshOrder;
        }
        catch
        {
            return null;
        }
    }
}