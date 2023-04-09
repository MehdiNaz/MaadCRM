namespace DataAccess.Repositories.Businesses;

public class BusinessRepository : IBusinessRepository
{
    private readonly MaadContext _context;

    public BusinessRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<IReadOnlyList<Business?>> GetAllBusinessesAsync() => (await _context.Businesses!.ToListAsync())!;


    public async ValueTask<Business?> GetBusinessByIdAsync(Ulid businessId) => await _context.Businesses!.FindAsync(businessId);

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

    public async ValueTask<Business> DeleteBusinessAsync(Ulid businessId)
    {
        try
        {
            var business = await GetBusinessByIdAsync(businessId);
            _context.Businesses!.Remove(business);
            await _context.SaveChangesAsync();
            return business;
        }
        catch
        {
            return null;
        }
    }
}