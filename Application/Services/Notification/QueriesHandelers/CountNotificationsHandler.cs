namespace Application.Services.Notification.QueriesHandelers;

public readonly struct CountNotificationsHandler : IRequestHandler<CountNotificationsQuery, Result<int>>
{
    private readonly INotificationRepository _repository;

    public CountNotificationsHandler(INotificationRepository
        repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(CountNotificationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.NotificationCountAsync(request)).Match(result => new Result<int>(result), exception => new Result<int>(exception));
        }
        catch (Exception e)
        {
            return new Result<int>(new Exception(e.Message));
        }
    }
}