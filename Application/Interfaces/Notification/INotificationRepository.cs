namespace Application.Interfaces.Notification;

public interface INotificationRepository
{
    ValueTask<Result<ICollection<NotificationResponse>>> AllNotificationAsync(string idUser);
    ValueTask<Result<NotificationResponse>> NotificationByIdAsync(Ulid idNotification);
    ValueTask<Result<int>> NotificationCountAsync(string idUser);
}