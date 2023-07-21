namespace Application.Services.Notification.Queries;

public struct AllNotificationsQuery : IRequest<Result<ICollection<NotificationResponse>>>
{
    public string IdUser { get; set; }
}