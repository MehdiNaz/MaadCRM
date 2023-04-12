namespace Application.Services.BusinessService.CommandHandler;

public readonly struct ChangeStatusBusinessCommandHandler : IRequestHandler<ChangeStatusBusinessCommand, Business?>
{
    private readonly IBusinessRepository _repository;

    public ChangeStatusBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Business?> Handle(ChangeStatusBusinessCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatsAsync(request.BusinessStatus, request.BusinessId);
}