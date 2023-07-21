namespace Application.Services.Notification.QueriesHandelers;

public readonly struct NotificationByIdHandler : IRequestHandler<NotificationsByIdQuery, Result<NotificationResponse>>
{
    private readonly INotificationRepository _repository;

    public NotificationByIdHandler(INotificationRepository
        repository)
    {
        _repository = repository;
    }

    public async Task<Result<NotificationResponse>> Handle(NotificationsByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.NotificationByIdAsync(request)).Match(result => new Result<NotificationResponse>(result), exception => new Result<NotificationResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new Exception(e.Message));
        }
    }
}