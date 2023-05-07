namespace Application.Services.ForoshFactorService.QueryHandler;

public readonly struct GetForoshFactorByIdHandler : IRequestHandler<GetForoshFactorByIdQuery, Result<ForooshFactor>>
{
    private readonly IForoshFactorRepository _repository;

    public GetForoshFactorByIdHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(GetForoshFactorByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetForoshFactorByIdAsync(request.ForoshFactorId))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}