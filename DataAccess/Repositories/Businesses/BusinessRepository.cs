namespace DataAccess.Repositories.Businesses;

public class BusinessRepository : IBusinessRepository
{
    private readonly MaadContext _context;
    private readonly UserManager<User> _userManager;
    public BusinessRepository(MaadContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async ValueTask<Result<ICollection<Business>>> GetAllBusinessesAsync()
    {
        try
        {
            return await _context.Businesses.Where(x => x.StatusBusiness == Status.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<Business>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Business>> GetBusinessByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<Business>> GetBusinessByIdAsync(Ulid businessId)
    {
        try
        {
            return await _context.Businesses.FirstOrDefaultAsync(x => x.Id == businessId && x.StatusBusiness == Status.Show);
        }
        catch (Exception e)
        {
            return new Result<Business>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Business>> GetBusinessNameByUserId(string userId)
    {
        try
        {
            var resultUser = await _userManager.FindByIdAsync(userId);
            var resultBusiness = await _context.Businesses.FindAsync(resultUser.IdBusiness);
            return resultBusiness;
        }
        catch (Exception e)
        {
            return new Result<Business>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Business>> ChangeStatsAsync(ChangeStatusBusinessCommand request)
    {
        try
        {
            var item = await _context.Businesses.FindAsync(request.BusinessId);
            if (item is null) return new Result<Business>(new ValidationException());
            item.StatusBusiness = request.BusinessStatus;
            await _context.SaveChangesAsync();
            return new Result<Business>(item);
        }
        catch (Exception e)
        {
            return new Result<Business>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Business>> CreateBusinessAsync(CreateBusinessCommand request)
    {
        try
        {
            Business item = new()
            {
                BusinessName = request.BusinessName,
                Url = request.Url,
                Hosts = request.Hosts,
                CompanyName = request.CompanyName,
                CompanyAddress = request.CompanyAddress,
                DisplayOrder = request.DisplayOrder
            };
            await _context.Businesses.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<Business>(item);
        }
        catch (Exception e)
        {
            return new Result<Business>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Business>> UpdateBusinessAsync(UpdateBusinessCommand request)
    {
        try
        {
            Business item = new()
            {
                Id = request.BusinessId,
                BusinessName = request.BusinessName,
                Url = request.Url,
                Hosts = request.Hosts,
                CompanyName = request.CompanyName,
                CompanyAddress = request.CompanyAddress,
                DisplayOrder = request.DisplayOrder
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return new Result<Business>(item);
        }
        catch (Exception e)
        {
            return new Result<Business>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Business>> DeleteBusinessAsync(Ulid id)
    {
        try
        {
            var business = await _context.Businesses.FindAsync(id);
            business.StatusBusiness = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<Business>(business);
        }
        catch (Exception e)
        {
            return new Result<Business>(new ValidationException(e.Message));
        }
    }
}