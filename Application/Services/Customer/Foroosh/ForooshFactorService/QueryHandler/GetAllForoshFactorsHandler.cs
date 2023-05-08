namespace Application.Services.Customer.Foroosh.ForooshFactorService.QueryHandler;

public readonly struct GetAllForooshFactorsHandler : IRequestHandler<AllForooshFactorsQuery, Result<ICollection<ForooshFactor>>>
{
    private readonly IForooshFactorRepository _repository;

    public GetAllForooshFactorsHandler(IForooshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ForooshFactor>>> Handle(AllForooshFactorsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllForooshFactorsAsync())
                .Match(result => new Result<ICollection<ForooshFactor>>(result),
                    exception => new Result<ICollection<ForooshFactor>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ForooshFactor>>(new Exception(e.Message));
        }
    }
}