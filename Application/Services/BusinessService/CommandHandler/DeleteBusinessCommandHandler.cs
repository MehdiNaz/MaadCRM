namespace Application.Services.BusinessService.CommandHandler;

public readonly struct DeleteBusinessCommandHandler : IRequestHandler<DeleteBusinessCommand, Business>
{
    private readonly IBusinessRepository _repository;

    public DeleteBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Business?> Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteBusinessAsync(request))!;
}