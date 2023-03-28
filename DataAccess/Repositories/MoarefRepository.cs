namespace DataAccess.Repositories;

public class MoarefRepository : IMoarefRepository
{
    private readonly MaadContext _context;

    public MoarefRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Moaref?>> GetAllMoarefsAsync()
        => (await _context.Moarefs!.ToListAsync()).Where(x => x.IsDeleted == (byte)Status.NotDeleted).ToList()!;

    public async ValueTask<Moaref?> GetMoarefByIdAsync(Ulid moarefId) => await _context.Moarefs!.FindAsync(moarefId);

    public async ValueTask<Moaref?> CreateMoarefAsync(Moaref? entity)
    {
        try
        {
            await _context.Moarefs!.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Moaref?> UpdateMoarefAsync(Moaref entity, Ulid moarefId)
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

    public async ValueTask<Moaref?> DeleteMoarefAsync(Ulid moarefId)
    {
        try
        {
            var item = await GetMoarefByIdAsync(moarefId);
            item!.IsDeleted = (byte)Status.Deleted;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }
}