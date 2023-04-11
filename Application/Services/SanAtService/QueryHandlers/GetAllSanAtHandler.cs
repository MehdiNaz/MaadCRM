namespace Application.Services.SanAtService.QueryHandlers;

public readonly struct GetAllContactHandler : IRequestHandler<GetAllSanAtQuery, ICollection<SanAt?>>
{
    private readonly ISanAtRepository _repository;

    public GetAllContactHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<SanAt?>> Handle(GetAllSanAtQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllSanAtsAsync();
}