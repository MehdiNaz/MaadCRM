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
        => await _context.SanAts.FirstOrDefaultAsync(x => x.Id == sanAtId && x.SanAtStatus == Status.Show);

    public async ValueTask<SanAt?> ChangeStatusSanAtsByIdAsync(ChangeStatusSanAtCommand request)
    {
        try
        {
            var item = await _context.SanAts!.FindAsync(request.Id);
            if (item is null) return null;
            item.SanAtStatus = request.SanAtStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<SanAt?> CreateSanAtsAsync(CreateSanAtCommand request)
    {
        try
        {
            SanAt item = new()
            {
                SanAtName = request.SanAtName,
                UserId = request.UserId
            };
            await _context.SanAts!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<SanAt?> UpdateSanAtsAsync(UpdateSanAtCommand request)
    {
        try
        {
            SanAt item = new()
            {
                SanAtName = request.SanAtName,
                UserId = request.UserId
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<SanAt?> DeleteSanAtsAsync(DeleteSanAtCommand request)
    {
        try
        {
            var sanAt = await GetSanAtsByIdAsync(request.Id);
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