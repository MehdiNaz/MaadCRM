namespace Application.Services.ForoshFactorService.QueryHandler;

public readonly struct GetForoshFactorByIdHandler : IRequestHandler<GetForoshFactorByIdQuery, ForoshFactor?>
{
    private readonly IForoshFactorRepository _repository;

    public GetForoshFactorByIdHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshFactor?> Handle(GetForoshFactorByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetForoshFactorByIdAsync(request.ForoshFactorId);
}