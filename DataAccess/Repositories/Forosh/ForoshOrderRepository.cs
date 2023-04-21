﻿namespace DataAccess.Repositories.Forosh;

public class ForoshOrderRepository : IForoshOrderRepository
{
    private readonly MaadContext _context;

    public ForoshOrderRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ForooshOrder?>> GetAllForoshOrdersAsync()
        => await _context.ForoshOrders.Where(x => x.ForoshOrderStatus == Status.Show).ToListAsync();

    public async ValueTask<ForooshOrder?> GetForoshOrderByIdAsync(Ulid foroshOrderId)
        => await _context.ForoshOrders.SingleOrDefaultAsync(x => x.Id == foroshOrderId && x.ForoshOrderStatus == Status.Show);

    public async ValueTask<ForooshOrder?> ChangeStatusForoshOrderByIdAsync(ChangeStatusForoshOrderCommand request)
    {
        try
        {
            var item = await _context.ForoshOrders!.FindAsync(request.ForoshOrderId);
            if (item is null) return null;
            item.ForoshOrderStatus = request.ForoshOrderStatus;
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
            ForooshOrder item = new()
            {
                PaymentDate = request.PaymentDate,
                Price = request.Price,
                ShippingPrice = request.ShippingPrice,
                PriceTotal = request.PriceTotal,
                DiscountPrice = request.DiscountPrice,
                Description = request.Description,
                PaymentMethodType = request.PaymentMethodType,
                ShippingMethodType = request.ShippingMethodType,
                ProductId = request.ProductId
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
            ForooshOrder item = new()
            {
                Id = request.Id,
                PaymentDate = request.PaymentDate,
                Price = request.Price,
                ShippingPrice = request.ShippingPrice,
                PriceTotal = request.PriceTotal,
                DiscountPrice = request.DiscountPrice,
                Description = request.Description,
                PaymentMethodType = request.PaymentMethodType,
                ShippingMethodType = request.ShippingMethodType,
                ProductId = request.ProductId
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

    public async ValueTask<ForooshOrder?> DeleteForoshOrderAsync(DeleteForoshOrderCommand request)
    {
        try
        {
            var foroshOrder = await GetForoshOrderByIdAsync(request.Id);
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