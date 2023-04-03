namespace DataAccess.Repositories;

public class LogRepository: ILogRepository
{
    private readonly MaadContext _context;

    public LogRepository(MaadContext context)
    {
        _context = context;
    }
    public async ValueTask<List<Log?>> GetAllLogs(LogKinds? logKind, string? userId, int skip, int take)
    {
        var logs = _context.Logs.AsNoTracking();
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                if (logKind != null) logs = logs.Where(x => x.Kind == logKind.Value);
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                if (!string.IsNullOrEmpty(userId)) logs = logs.Where(x => x.UserId == userId);
        
                return await logs
                    .Include(u => u.User)
                    .OrderByDescending(x => x.DateCreated)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
    }

    public async ValueTask<Log?> GetLogById(int postId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Log> CreateLog(Log toCreate)
    {
        await _context.Logs.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<Log?> UpdateLog(string updateContent, int logId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask DeleteLog(int logId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<int> CountLog(string userId)
    {
        IQueryable<Log> logs = _context.Logs.Where(l => l.UserId == userId);
        // if (logKind != null) logs = logs.Where(x => x.Kind == logKind.Value);

        return await logs.CountAsync();
    }
}