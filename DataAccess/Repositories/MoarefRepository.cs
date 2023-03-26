namespace DataAccess.Repositories;

public class MoarefRepository : IMoarefRepository
{
    private readonly MaadContext _context;

    public MoarefRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Moaref?>> GetAllMoarefsAsync() => (await _context.Moarefs!.ToListAsync())!;

    public async ValueTask<Moaref?> GetMoarefByIdAsync(int moarefId) => await _context.Moarefs!.FindAsync(moarefId);

    public async ValueTask<Moaref?> CreateMoarefAsync(Moaref? toCreate)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Moaref?> UpdateMoarefAsync(string updateContent, int moarefId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask DeleteMoarefAsync(int moarefId)
    {
        throw new NotImplementedException();
    }
}