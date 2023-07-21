namespace Application.Services.Notification.Queries;

public struct NotificationsByIdQuery : IRequest<Result<NotificationResponse>>
{
    public string IdUser { get; set; }
    public Ulid IdNotification { get; set; }
}