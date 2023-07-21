namespace Application.Services.Notification.Commands;

public struct NotificationCanceledCommand : IRequest<Result<NotificationResponse>>
{
    public string IdUser { get; set; }
    public Ulid IdNotification { get; set; }
}