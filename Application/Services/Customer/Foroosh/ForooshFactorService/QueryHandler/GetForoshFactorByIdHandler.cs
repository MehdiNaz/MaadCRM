namespace Application.Services.Customer.Foroosh.ForooshFactorService.QueryHandler;

public readonly struct GetForooshFactorByIdHandler : IRequestHandler<ForooshFactorByIdQuery, Result<ForooshFactor>>
{
    private readonly IForooshFactorRepository _repository;

    public GetForooshFactorByIdHandler(IForooshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(ForooshFactorByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetForooshFactorByIdAsync(request.ForooshFactorId))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}