using Application.Interfaces.Notification;
using Application.Responses.Notification;

namespace DataAccess.Repositories.Notification;

public class NotificationRepository : INotificationRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public NotificationRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }
    
    public async ValueTask<Result<ICollection<NotificationResponse>>> AllNotificationAsync(string idUser)
    {
        try
        {
            var result = await _context
                .Notifications
                .Where(w => w.IdUser == idUser && w.Status == StatusType.Show)
                .Select(s => new NotificationResponse
                {
                    Id = s.Id,
                    Description = s.Description,
                    Message = s.Message,
                    Status = s.Status,
                    DateDue = s.DateDue,
                    DateAlarm = s.DateAlarm,
                    NotificationType = s.NotificationType,
                    Url = s.Url,
                    IsRead = s.IsRead,
                    IdUser = s.IdUser,
                    IdPeyGiry = s.IdPeyGiry,
                })
                .ToListAsync();
                
            return new Result<ICollection<NotificationResponse>>(result);
        }
        catch (Exception e)
        {
            return new Result<ICollection<NotificationResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<NotificationResponse>> NotificationByIdAsync(Ulid idNotification)
    {
        try
        {
            var findResult = await _context.Notifications.FirstOrDefaultAsync(f => f.Id == idNotification);
            if (findResult is null) return new Result<NotificationResponse>(new ValidationException("اطلاعیه ای یافت نشد"));
            findResult.IsRead = true;
            await _context.SaveChangesAsync();
            
            var result = await _context
                .Notifications
                .Include(i => i.IdPeyGiryNavigation)
                .Select(s => new NotificationResponse
                {
                    Id = s.Id,
                    Description = s.Description,
                    Message = s.Message,
                    Status = s.Status,
                    DateDue = s.DateDue,
                    DateAlarm = s.DateAlarm,
                    NotificationType = s.NotificationType,
                    Url = s.Url,
                    IsRead = s.IsRead,
                    IdPeyGiry = s.IdPeyGiry,
                    IdUser = s.IdUser,
                    IdPeyGiryNavigation = s.IdPeyGiryNavigation
                })
                .FirstOrDefaultAsync(f => f.Id == idNotification);
                
            return new Result<NotificationResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> NotificationCountAsync(string idUser)
    {
        try
        {
            var result = await _context
                .Notifications
                .Where(w => w.IdUser == idUser && w.Status == StatusType.Show)
                .CountAsync();
                
            return new Result<int>(result);
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }
}