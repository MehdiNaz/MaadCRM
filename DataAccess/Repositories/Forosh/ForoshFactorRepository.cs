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
        => await _context.ForoshFactors.FindAsync(foroshFactorId);

    public async ValueTask<ForoshFactor?> CreateForoshFactorAsync(ForoshFactor? entity)
    {
        try
        {
            await _context.ForoshFactors!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ForoshFactor?> UpdateForoshFactorAsync(ForoshFactor entity, Ulid foroshFactorId)
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

    public async ValueTask<ForoshFactor?> DeleteForoshFactorAsync(Ulid foroshFactorId)
    {
        try
        {
            var foroshFactor = await GetForoshFactorByIdAsync(foroshFactorId);
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