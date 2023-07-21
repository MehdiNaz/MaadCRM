namespace Application.Services.Notification.Commands;

public struct NotificationLaterCommand : IRequest<Result<NotificationResponse>>
{
    public string IdUser { get; set; }
    public Ulid IdNotification { get; set; }
}