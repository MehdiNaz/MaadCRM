namespace Application.Services.Notification.CommandHandlers;

public readonly struct NotificationCompletedCommandHandler : IRequestHandler<NotificationCompletedCommand, Result<NotificationResponse>>
{
    private readonly INotificationRepository _repository;

    public NotificationCompletedCommandHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<NotificationResponse>> Handle(NotificationCompletedCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.NotificationCompletedAsync(request))
                .Match(result => new Result<NotificationResponse>(result),
                    exception => new Result<NotificationResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new Exception(e.Message));
        }
    }
}