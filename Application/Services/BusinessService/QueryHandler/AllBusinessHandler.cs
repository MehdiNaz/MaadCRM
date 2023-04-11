namespace Application.Services.BusinessService.QueryHandler;

public readonly struct AllBusinessHandler : IRequestHandler<AllBusinessQuery, ICollection<Business?>>
{
    private readonly IBusinessRepository _repository;

    public AllBusinessHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Business?>> Handle(AllBusinessQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllBusinessesAsync()).ToList();
}