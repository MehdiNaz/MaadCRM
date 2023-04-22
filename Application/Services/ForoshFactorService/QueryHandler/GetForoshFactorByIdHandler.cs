using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.QueryHandler;

public readonly struct GetForoshFactorByIdHandler : IRequestHandler<GetForoshFactorByIdQuery, ForooshFactor?>
{
    private readonly IForoshFactorRepository _repository;

    public GetForoshFactorByIdHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshFactor?> Handle(GetForoshFactorByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetForoshFactorByIdAsync(request.ForoshFactorId);
}