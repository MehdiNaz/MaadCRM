namespace DataAccess.Repositories.Businesses;

public class BusinessRepository : IBusinessRepository
{
    private readonly MaadContext _context;

    public BusinessRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<IReadOnlyList<Business?>> GetAllBusinessesAsync()
        => await _context.Businesses!.Where(x => x.BusinessStatus == Status.Show).ToListAsync()!;

    public async ValueTask<Business?> GetBusinessByIdAsync(Ulid businessId)
        => await _context.Businesses!.FirstOrDefaultAsync(x => x.Id == businessId && x.BusinessStatus == Status.Show);

    public async ValueTask<Business?> ChangeStatsAsync(ChangeStatusBusinessCommand request)
    {
        try
        {
            var item = await _context.Businesses!.FindAsync(request.BusinessId);
            if (item is null) return null;
            item.BusinessStatus = request.BusinessStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Business?> CreateBusinessAsync(CreateBusinessCommand request)
    {
        try
        {
            Business business = new()
            {
                BusinessName = request.BusinessName,
                Url = request.Url,
                Hosts = request.Hosts,
                CompanyName = request.CompanyName,
                CompanyAddress = request.CompanyAddress,
                DisplayOrder = request.DisplayOrder
            };
            await _context.Businesses!.AddAsync(business);
            await _context.SaveChangesAsync();
            return business;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Business?> UpdateBusinessAsync(UpdateBusinessCommand request)
    {
        try
        {
            Business business = new()
            {
                Id = request.BusinessId,
                BusinessName = request.BusinessName,
                Url = request.Url,
                Hosts = request.Hosts,
                CompanyName = request.CompanyName,
                CompanyAddress = request.CompanyAddress,
                DisplayOrder = request.DisplayOrder
            };

            _context.Update(business);
            await _context.SaveChangesAsync();
            return business;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Business?> DeleteBusinessAsync(DeleteBusinessCommand request)
    {
        try
        {
            var business = await GetBusinessByIdAsync(request.BusinessId);
            business.BusinessStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return business;
        }
        catch
        {
            return null;
        }
    }
}