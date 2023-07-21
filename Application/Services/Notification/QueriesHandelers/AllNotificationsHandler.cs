namespace Application.Services.Notification.QueriesHandelers;

public readonly struct AllNotificationsHandler : IRequestHandler<AllNotificationsQuery, Result<ICollection<NotificationResponse>>>
{
    private readonly INotificationRepository _repository;

    public AllNotificationsHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<NotificationResponse>>> Handle(AllNotificationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.AllNotificationAsync(request)).Match(result => new Result<ICollection<NotificationResponse>>(result), exception => new Result<ICollection<NotificationResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<NotificationResponse>>(new Exception(e.Message));
        }
    }
}