namespace DataAccess.Repositories;

public class SanAtRepository : ISanAtRepository
{
    private readonly MaadContext _context;

    public SanAtRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<SanAt?>> GetAllSanAtsAsync()
        => await _context.SanAts!.Where(x => x.SanAtStatus == Status.Show).ToListAsync();

    public async ValueTask<SanAt?> GetSanAtsByIdAsync(Ulid sanAtId)
        => await _context.SanAts.FindAsync(sanAtId);

    public async ValueTask<SanAt?> CreateSanAtsAsync(SanAt? entity)
    {
        try
        {
            await _context.SanAts!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<SanAt?> UpdateSanAtsAsync(SanAt? entity, Ulid sanAtId)
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

    public async ValueTask<SanAt?> DeleteSanAtsAsync(Ulid sanAtId)
    {
        try
        {
            var sanAt = await GetSanAtsByIdAsync(sanAtId);
            sanAt.SanAtStatus = Status.Show;
            await _context.SaveChangesAsync();
            return sanAt;
        }
        catch
        {
            return null;
        }
    }
}