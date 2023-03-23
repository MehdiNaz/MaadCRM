namespace DataAccess.Repositories;

public class SanAtRepository : ISanAtRepository
{
    private readonly MaadContext _context;

    public SanAtRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<SanAt?>> GetAllSanAtsAsync() => await _context.SanAts.ToListAsync();

    public async ValueTask<SanAt?> GetSanAtsByIdAsync(int sanAtId) => await _context.SanAts.FindAsync(sanAtId);

    public async ValueTask<SanAt?> CreateSanAtsAsync(SanAt? toCreate)
    {
        await _context.SanAts.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<SanAt?> UpdateSanAtsAsync(string updateContent, int sanAtId)
    {
        var sanAt = await GetSanAtsByIdAsync(sanAtId);
        _context.Update(sanAt);
        await _context.SaveChangesAsync();
        return sanAt;
    }

    public async ValueTask DeleteSanAtsAsync(int sanAtId)
    {
        var sanAt = await GetSanAtsByIdAsync(sanAtId);
        _context.SanAts.Remove(sanAt);
        await _context.SaveChangesAsync();
    }
}