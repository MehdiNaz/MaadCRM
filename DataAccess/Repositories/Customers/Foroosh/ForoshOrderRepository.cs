namespace DataAccess.Repositories.Customers.Foroosh;

public class ForooshOrderRepository : IForooshOrderRepository
{
    private readonly MaadContext _context;

    public ForooshOrderRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ForooshOrder>>> GetAllForooshOrdersAsync()
    {
        try
        {
            return await _context.ForooshOrders.Where(x => x.StatusTypeForooshOrder == StatusType.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ForooshOrder>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshOrder>> GetForooshOrderByIdAsync(Ulid ForooshOrderId)
    {
        try
        {
            return await _context.ForooshOrders.SingleOrDefaultAsync(x => x.Id == ForooshOrderId && x.StatusTypeForooshOrder == StatusType.Show);
        }
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshOrder>> ChangeStatusForooshOrderByIdAsync(ChangeStatusForooshOrderCommand request)
    {
        try
        {
            var item = await _context.ForooshOrders!.FindAsync(request.ForooshOrderId);
            if (item is null) return new Result<ForooshOrder>(new ValidationException(ResultErrorMessage.NotFound)); ;
            item.StatusTypeForooshOrder = request.ForooshOrderStatusType;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshOrder>> CreateForooshOrderAsync(CreateForooshOrderCommand request)
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
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshOrder>> UpdateForooshOrderAsync(UpdateForooshOrderCommand request)
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
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshOrder>> DeleteForooshOrderAsync(Ulid id)
    {
        try
        {
            var item = await _context.ForooshOrders.FindAsync(id);
            item.StatusTypeForooshOrder = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new ValidationException(e.Message));
        }
    }
}