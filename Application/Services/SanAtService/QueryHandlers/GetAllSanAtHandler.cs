namespace Application.Services.SanAtService.QueryHandlers;

public class GetAllSanAtHandler : IRequestHandler<GetAllSanAtQuery, ICollection<SanAt?>>
{
    private readonly ISanAtRepository _repository;

    public GetAllSanAtHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<SanAt?>> Handle(GetAllSanAtQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllSanAtsAsync();
}