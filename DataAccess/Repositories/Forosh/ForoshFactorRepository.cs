namespace DataAccess.Repositories.Forosh;

public class ForoshFactorRepository : IForoshFactorRepository
{
    private readonly MaadContext _context;

    public ForoshFactorRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ForooshFactor?>> GetAllForoshFactorsAsync()
        => await _context.ForoshFactors.Where(x => x.StatusForooshFactor == Status.Show).ToListAsync();

    public async ValueTask<ForooshFactor?> GetForoshFactorByIdAsync(Ulid foroshFactorId)
        => await _context.ForoshFactors.SingleOrDefaultAsync(x => x.Id == foroshFactorId && x.StatusForooshFactor == Status.Show);

    public async ValueTask<ForooshFactor?> ChangeStatusForoshFactorByIdAsync(ChangeStatusForoshFactorCommand request)
    {
        try
        {
            var item = await _context.ForoshFactors!.FindAsync(request.Id);
            if (item is null) return null;
            item.StatusForooshFactor = request.ForoshFactorStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForooshFactor?> CreateForoshFactorAsync(CreateForoshFactorCommand request)
    {
        try
        {
            ForooshFactor item = new()
            {
                Price = request.Price,
                DiscountPrice = request.DiscountPrice,
                PriceTotal = request.FinalTotal,
                IdCustomer = request.CustomerId,
                IdCustomerAddress = request.CustomersAddressId
            };
            await _context.ForoshFactors!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForooshFactor?> UpdateForoshFactorAsync(UpdateForoshFactorCommand request)
    {
        try
        {
            ForooshFactor item = await _context.ForoshFactors.FindAsync(request.Id);
           
            item.Price = request.Price;
            item.DiscountPrice = request.DiscountPrice;
            item.PriceTotal = request.FinalTotal;
            item.IdCustomer = request.CustomerId;
            item.IdCustomerAddress = request.CustomersAddressId;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForooshFactor?> DeleteForoshFactorAsync(Ulid id)
    {
        try
        {
            var foroshFactor = await _context.ForoshFactors.FindAsync(id);
            foroshFactor!.StatusForooshFactor = Status.Deleted;
            await _context.SaveChangesAsync();
            return foroshFactor;
        }
        catch
        {
            return null;
        }
    }
}