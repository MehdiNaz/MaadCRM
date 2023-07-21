namespace Application.Services.Notification.Queries;

public struct CountNotificationsQuery : IRequest<Result<int>>
{
    public string IdUser { get; set; }
}