namespace Application.Interfaces.Notification;

public interface INotificationRepository
{
    ValueTask<Result<ICollection<NotificationResponse>>> AllNotificationAsync(AllNotificationsQuery request);
    ValueTask<Result<NotificationResponse>> NotificationByIdAsync(NotificationsByIdQuery request);
    ValueTask<Result<int>> NotificationCountAsync(CountNotificationsQuery request);
    ValueTask<Result<NotificationResponse>> NotificationCompletedAsync(NotificationCompletedCommand request);
    ValueTask<Result<NotificationResponse>> NotificationCancelAsync(NotificationCanceledCommand request);
    ValueTask<Result<NotificationResponse>> NotificationLaterAsync(NotificationLaterCommand request);
}