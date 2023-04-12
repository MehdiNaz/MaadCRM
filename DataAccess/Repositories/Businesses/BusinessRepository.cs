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
        => await _context.Businesses!.FirstOrDefaultAsync(x => x.BusinessId == businessId && x.BusinessStatus == Status.Show);

    public async ValueTask<Business?> ChangeStatsAsync(Status status, Ulid businessId)
    {
        try
        {
            var item = await _context.Businesses!.FindAsync(businessId);
            if (item is null) return null;
            item.BusinessStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Business?> CreateBusinessAsync(Business? entity)
    {
        try
        {
            await _context.Businesses!.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Business?> UpdateBusinessAsync(Business entity)
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

    public async ValueTask<Business?> DeleteBusinessAsync(Ulid businessId)
    {
        try
        {
            var business = await GetBusinessByIdAsync(businessId);
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