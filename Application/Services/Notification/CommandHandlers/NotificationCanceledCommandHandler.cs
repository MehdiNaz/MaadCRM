namespace Application.Services.Notification.CommandHandlers;

public readonly struct NotificationCanceldCommandHandler : IRequestHandler<NotificationCanceledCommand, Result<NotificationResponse>>
{
    private readonly INotificationRepository _repository;

    public NotificationCanceldCommandHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<NotificationResponse>> Handle(NotificationCanceledCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.NotificationCancelAsync(request))
                .Match(result => new Result<NotificationResponse>(result),
                    exception => new Result<NotificationResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new Exception(e.Message));
        }
    }
}