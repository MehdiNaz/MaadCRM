namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct ChangeStatusForoshFactorCommandHandler : IRequestHandler<ChangeStatusForoshFactorCommand, ForoshFactor?>
{
    private readonly IForoshFactorRepository _repository;

    public ChangeStatusForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshFactor?> Handle(ChangeStatusForoshFactorCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusForoshFactorByIdAsync(request.ForoshFactorStatus, request.ForoshFactorId);
}