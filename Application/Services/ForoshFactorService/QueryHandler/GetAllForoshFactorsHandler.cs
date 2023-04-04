namespace Application.Services.ForoshFactorService.QueryHandler;

public class GetAllForoshFactorsHandler : IRequestHandler<GetAllForoshFactorsQuery, ICollection<ForoshFactor?>>
{
    private readonly IForoshFactorRepository _repository;

    public GetAllForoshFactorsHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ForoshFactor?>> Handle(GetAllForoshFactorsQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllForoshFactorsAsync();
}