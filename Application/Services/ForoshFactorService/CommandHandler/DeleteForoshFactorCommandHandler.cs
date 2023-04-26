using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct DeleteForoshFactorCommandHandler : IRequestHandler<DeleteForoshFactorCommand, ForooshFactor>
{
    private readonly IForoshFactorRepository _repository;

    public DeleteForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshFactor> Handle(DeleteForoshFactorCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteForoshFactorAsync(request.Id))!;
}