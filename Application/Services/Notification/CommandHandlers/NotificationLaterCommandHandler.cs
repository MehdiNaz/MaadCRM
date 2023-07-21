namespace Application.Services.Notification.CommandHandlers;

public readonly struct NotificationLaterCommandHandler : IRequestHandler<NotificationLaterCommand, Result<NotificationResponse>>
{
    private readonly INotificationRepository _repository;

    public NotificationLaterCommandHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<NotificationResponse>> Handle(NotificationLaterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.NotificationLaterAsync(request))
                .Match(result => new Result<NotificationResponse>(result),
                    exception => new Result<NotificationResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<NotificationResponse>(new Exception(e.Message));
        }
    }
}