namespace DataAccess.Repositories.Forosh;

public class ForoshFactorRepository : IForoshFactorRepository
{
    private readonly MaadContext _context;

    public ForoshFactorRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ForoshFactor?>> GetAllForoshFactorsAsync()
        => await _context.ForoshFactors.Where(x => x.ForoshFactorStatus == Status.Show).ToListAsync();

    public async ValueTask<ForoshFactor?> GetForoshFactorByIdAsync(Ulid foroshFactorId)
        => await _context.ForoshFactors.SingleOrDefaultAsync(x => x.Id == foroshFactorId && x.ForoshFactorStatus == Status.Show);

    public async ValueTask<ForoshFactor?> ChangeStatusForoshFactorByIdAsync(ChangeStatusForoshFactorCommand request)
    {
        try
        {
            var item = await _context.ForoshFactors!.FindAsync(request.Id);
            if (item is null) return null;
            item.ForoshFactorStatus = request.ForoshFactorStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForoshFactor?> CreateForoshFactorAsync(CreateForoshFactorCommand request)
    {
        try
        {
            ForoshFactor item = new()
            {
                Price = request.Price,
                DiscountPrice = request.DiscountPrice,
                FinalTotal = request.FinalTotal,
                CustomerId = request.CustomerId,
                CustomersAddressId = request.CustomersAddressId
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

    public async ValueTask<ForoshFactor?> UpdateForoshFactorAsync(UpdateForoshFactorCommand request)
    {
        try
        {
            ForoshFactor item = new()
            {
                Id = request.Id,
                Price = request.Price,
                DiscountPrice = request.DiscountPrice,
                FinalTotal = request.FinalTotal,
                CustomerId = request.CustomerId,
                CustomersAddressId = request.CustomersAddressId
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

    public async ValueTask<ForoshFactor?> DeleteForoshFactorAsync(DeleteForoshFactorCommand request)
    {
        try
        {
            var foroshFactor = await GetForoshFactorByIdAsync(request.Id);
            foroshFactor!.ForoshFactorStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return foroshFactor;
        }
        catch
        {
            return null;
        }
    }
}