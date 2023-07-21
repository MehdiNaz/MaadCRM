using Application.Services.Notification.Commands;

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
    
    private async ValueTask<Result<NotificationResponse>> GetNotificationByIdAsync(Ulid idNotification)
    {
        try
        {
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
                    IdPeyGiryNavigation = new CustomerPeyGiryResponse
                    {
                        Description = s.IdPeyGiryNavigation.Description,
                        DateCreated = s.IdPeyGiryNavigation.DateCreated,
                        IdCustomerPeyGiry = s.IdPeyGiryNavigation.IdCustomer,
                        DatePeyGiry = s.IdPeyGiryNavigation.DatePeyGiry,
                        IdCustomer = s.IdPeyGiryNavigation.IdCustomer,
                        NameCustomer = s.IdPeyGiryNavigation.IdCustomerNavigation.FirstName + " " + s.IdPeyGiryNavigation.IdCustomerNavigation.LastName,
                        // NameCustomer = s.IdPeyGiryNavigation != null ? 
                        //     s.IdPeyGiryNavigation.IdCustomerNavigation.FirstName != null ?  
                        //         s.IdPeyGiryNavigation.IdCustomerNavigation.FirstName : "" + 
                        //     " " + s.IdPeyGiryNavigation.IdCustomerNavigation.LastName : "",
                        IdUser = s.IdPeyGiryNavigation != null ? s.IdPeyGiryNavigation.IdUser : "",
                        NameUser = s.IdPeyGiryNavigation.IdUserNavigation.Name + " " + s.IdPeyGiryNavigation.IdUserNavigation.Family,
                        IdPeyGiryCategory = s.IdPeyGiryNavigation.IdPeyGiryCategory,
                        NamePeyGiryCategory = s.IdPeyGiryNavigation.IdPeyGiryCategoryNavigation.Kind,
                    }
                })
                .FirstOrDefaultAsync(f => f.Id == idNotification);
                
            return new Result<NotificationResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new ValidationException(e.Message));
        }
    }
    
    public async ValueTask<Result<ICollection<NotificationResponse>>> AllNotificationAsync(AllNotificationsQuery request)
    {
        try
        {
            var result = await _context
                .Notifications
                .Where(w => w.IdUser == request.IdUser && w.Status == StatusType.Show)
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

    public async ValueTask<Result<NotificationResponse>> NotificationByIdAsync(NotificationsByIdQuery request)
    {
        try
        {
            var findResult = await _context.Notifications.FirstOrDefaultAsync(f => f.Id == request.IdNotification);
            if (findResult is null) return new Result<NotificationResponse>(new ValidationException("اطلاعیه ای یافت نشد"));
            findResult.IsRead = true;
            await _context.SaveChangesAsync();
            
            return await GetNotificationByIdAsync(request.IdNotification);
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> NotificationCountAsync(CountNotificationsQuery request)
    {
        try
        {
            var result = await _context
                .Notifications
                .Where(w => w.IdUser == request.IdUser && w.Status == StatusType.Show)
                .CountAsync();
                
            return new Result<int>(result);
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }
    
    public async ValueTask<Result<NotificationResponse>> NotificationCompletedAsync(NotificationCompletedCommand request)
    {
        try
        {
            var findResult = await _context.Notifications.FirstOrDefaultAsync(f => f.Id == request.IdNotification);
            if (findResult is null) return new Result<NotificationResponse>(new ValidationException("اطلاعیه ای یافت نشد"));
            findResult.Status = StatusType.Hidden;
            await _context.SaveChangesAsync();
            
            var findPeyGiry = await _context.CustomerPeyGiries.FirstOrDefaultAsync(f => f.Id == findResult.IdPeyGiry);
            if (findPeyGiry is null) return new Result<NotificationResponse>(new ValidationException("پیگیری یافت نشد"));
            findPeyGiry.PeyGiryStatus = PeyGiryStatusType.Completed;
            await _context.SaveChangesAsync();
            
            return await GetNotificationByIdAsync(request.IdNotification);
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new ValidationException(e.Message));
        }
    }
    
    public async ValueTask<Result<NotificationResponse>> NotificationCancelAsync(NotificationCanceledCommand request)
    {
        try
        {
            var findResult = await _context.Notifications.FirstOrDefaultAsync(f => f.Id == request.IdNotification);
            if (findResult is null) return new Result<NotificationResponse>(new ValidationException("اطلاعیه ای یافت نشد"));
            findResult.Status = StatusType.Hidden;
            await _context.SaveChangesAsync();
            
            var findPeyGiry = await _context.CustomerPeyGiries.FirstOrDefaultAsync(f => f.Id == findResult.IdPeyGiry);
            if (findPeyGiry is null) return new Result<NotificationResponse>(new ValidationException("پیگیری یافت نشد"));
            findPeyGiry.PeyGiryStatus = PeyGiryStatusType.Cancel;
            await _context.SaveChangesAsync();
            
            return await GetNotificationByIdAsync(request.IdNotification);
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new ValidationException(e.Message));
        }
    }
    
    public async ValueTask<Result<NotificationResponse>> NotificationLaterAsync(NotificationLaterCommand request)
    {
        try
        {
            var findResult = await _context.Notifications.FirstOrDefaultAsync(f => f.Id == request.IdNotification);
            if (findResult is null) return new Result<NotificationResponse>(new ValidationException("اطلاعیه ای یافت نشد"));
            findResult.Status = StatusType.Hidden;
            
            var findPeyGiry = await _context
                .CustomerPeyGiries
                .Include(i => i.IdPeyGiryCategoryNavigation)
                .Include(i => i.IdCustomerNavigation)
                .FirstOrDefaultAsync(f => f.Id == findResult.IdPeyGiry);
            if (findPeyGiry is null) return new Result<NotificationResponse>(new ValidationException("پیگیری یافت نشد"));
            findPeyGiry.PeyGiryStatus = PeyGiryStatusType.Later;
            findPeyGiry.DatePeyGiry = request.DateDue;
            findResult.DateDue = request.DateDue;
            
            Notif notif = new()
            {
                IdPeyGiry = findPeyGiry.Id,
                NotificationType = NotificationType.PeyGiry,
                Status = StatusType.Show,
                IdUser = findPeyGiry.IdUser,
                DateDue = request.DateDue,
                DateAlarm = request.DateDue,
                IdUserAdded = request.IdUser,
                IdUserUpdated = request.IdUser,
                Message = "  پیگیری" + findPeyGiry.IdPeyGiryCategoryNavigation.Kind + "  " + 
                          findPeyGiry.IdCustomerNavigation.FirstName + " " + 
                          findPeyGiry.IdCustomerNavigation.LastName
            };
            await _context.Notifications.AddAsync(notif);
            
            await _context.SaveChangesAsync();
            
            return await GetNotificationByIdAsync(request.IdNotification);
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new ValidationException(e.Message));
        }
    }
}