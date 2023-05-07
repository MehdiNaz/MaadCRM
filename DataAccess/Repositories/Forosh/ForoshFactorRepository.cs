namespace DataAccess.Repositories.Forosh;

public class ForoshFactorRepository : IForoshFactorRepository
{
    private readonly MaadContext _context;

    public ForoshFactorRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ForooshFactor>>> GetAllForoshFactorsAsync()
    {
        try
        {
            return await _context.ForoshFactors.Where(x => x.StatusForooshFactor == Status.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ForooshFactor>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> GetForoshFactorByIdAsync(Ulid foroshFactorId)
    {
        try
        {
            return await _context.ForoshFactors.SingleOrDefaultAsync(x => x.Id == foroshFactorId && x.StatusForooshFactor == Status.Show);
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> ChangeStatusForoshFactorByIdAsync(ChangeStatusForoshFactorCommand request)
    {
        try
        {
            var item = await _context.ForoshFactors.FindAsync(request.Id);
            if (item is null) return new Result<ForooshFactor>(new ValidationException(ResultErrorMessage.NotFound));
            item.StatusForooshFactor = request.ForoshFactorStatus;
            await _context.SaveChangesAsync();

            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> CreateForoshFactorAsync(CreateForoshFactorCommand request)
    {
        try
        {
            ForooshFactor item = new()
            {
                Amount = request.Amount,
                AmountTax = request.AmountTax,
                AmountTotal = request.AmountTotal,
                PaymentMethod = request.PaymentMethod,
                ShippingMethodType = request.ShippingMethodType,
                IdCustomer = request.CustomerId,
                IdCustomerAddress = request.CustomersAddressId
            };
            await _context.ForoshFactors.AddAsync(item);
            await _context.SaveChangesAsync();


            //if (request.PaymentMethodTypes==)
            //{

            //}

            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> UpdateForoshFactorAsync(UpdateForoshFactorCommand request)
    {
        try
        {
            ForooshFactor item = await _context.ForoshFactors.FindAsync(request.Id);

            item.IdCustomer = request.CustomerId;
            item.IdCustomerAddress = request.CustomersAddressId;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> DeleteForoshFactorAsync(Ulid id)
    {
        try
        {
            var foroshFactor = await _context.ForoshFactors.FindAsync(id);
            foroshFactor!.StatusForooshFactor = Status.Deleted;
            await _context.SaveChangesAsync();
            return foroshFactor;
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }
}