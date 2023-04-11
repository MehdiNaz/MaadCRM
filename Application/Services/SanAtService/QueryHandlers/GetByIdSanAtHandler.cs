namespace Application.Services.SanAtService.QueryHandlers;

public readonly struct GetByIdSanAtHandler : IRequestHandler<GetByIdSanAtQuery, SanAt?>
{
    private readonly ISanAtRepository _repository;

    public GetByIdSanAtHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<SanAt?> Handle(GetByIdSanAtQuery request, CancellationToken cancellationToken)
        => await _repository.GetSanAtsByIdAsync(request.SanAtId);
}
