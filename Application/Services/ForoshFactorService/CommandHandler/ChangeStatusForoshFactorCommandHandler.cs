using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct ChangeStatusForoshFactorCommandHandler : IRequestHandler<ChangeStatusForoshFactorCommand, ForooshFactor?>
{
    private readonly IForoshFactorRepository _repository;

    public ChangeStatusForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshFactor?> Handle(ChangeStatusForoshFactorCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusForoshFactorByIdAsync(request);
}