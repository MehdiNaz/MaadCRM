using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.QueryHandler;

public readonly struct GetAllForoshFactorsHandler : IRequestHandler<GetAllForoshFactorsQuery, ICollection<ForooshFactor?>>
{
    private readonly IForoshFactorRepository _repository;

    public GetAllForoshFactorsHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ForooshFactor?>> Handle(GetAllForoshFactorsQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllForoshFactorsAsync();
}