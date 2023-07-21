namespace Application.Services.Notification.Commands;

public struct NotificationCompletedCommand : IRequest<Result<NotificationResponse>>
{
    public string? IdUser { get; set; }
    public Ulid IdNotification { get; set; }
}