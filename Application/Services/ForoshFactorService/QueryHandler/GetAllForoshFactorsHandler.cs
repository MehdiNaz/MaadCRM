namespace Application.Services.ForoshFactorService.QueryHandler;

public readonly struct GetAllForoshFactorsHandler : IRequestHandler<GetAllForoshFactorsQuery, Result<ICollection<ForooshFactor>>>
{
    private readonly IForoshFactorRepository _repository;

    public GetAllForoshFactorsHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ForooshFactor>>> Handle(GetAllForoshFactorsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllForoshFactorsAsync())
                .Match(result => new Result<ICollection<ForooshFactor>>(result),
                    exception => new Result<ICollection<ForooshFactor>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ForooshFactor>>(new Exception(e.Message));
        }
    }
}