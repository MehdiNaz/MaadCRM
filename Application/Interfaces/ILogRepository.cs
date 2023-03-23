using Domain.Enum;
using Domain.Models;

namespace Application.Interfaces;

public interface ILogRepository
{
    Task<List<Log?>> GetAllLogs(LogKinds? logKind, string? userId, int skip, int take);
    Task<Log?> GetLogById(int logId);
    Task<Log> CreateLog(Log toCreate);
    Task<Log?> UpdateLog(string updateContent, int logId);
    Task DeleteLog(int logId);
    Task<int> CountLog(string userId);

}