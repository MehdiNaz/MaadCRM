namespace Application.Interfaces;

public interface ILogRepository
{
    ValueTask<List<Log?>> GetAllLogs(LogKinds? logKind, string? userId, int skip, int take);
    ValueTask<Log?> GetLogById(int logId);
    ValueTask<Log> CreateLog(Log toCreate);
    ValueTask<Log?> UpdateLog(string updateContent, int logId);
    ValueTask DeleteLog(int logId);
    ValueTask<int> CountLog(string userId);
}