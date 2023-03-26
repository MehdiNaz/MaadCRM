namespace DataAccess.Repositories;

public class BusinessRepository : IBusinessRepository
{
    private readonly MaadContext _context;

    public BusinessRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<Business?>> GetAllBusinessesAsync() => (await _context.Businesses!.ToListAsync())!;


    public async ValueTask<Business?> GetBusinessByIdAsync(int businessId) => await _context.Businesses!.FindAsync(businessId);

    public async ValueTask<Business?> CreateBusinessAsync(Business? toCreate)
    {
        await _context.Businesses!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<Business?> UpdateBusinessAsync(string updateContent, int businessId)
    {
        var business = await GetBusinessByIdAsync(businessId);
        _context.Update(business);
        await _context.SaveChangesAsync();
        return business;
    }

    public async ValueTask DeleteBusinessAsync(int businessId)
    {
        var business = await GetBusinessByIdAsync(businessId);
        _context.Businesses!.Remove(business);
        await _context.SaveChangesAsync();
    }
}