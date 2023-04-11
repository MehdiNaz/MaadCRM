namespace Application.Services.CityService.QueryHandler;

public readonly struct GetAllCityHandler : IRequestHandler<GetAllCitiesQuery, ICollection<City>>
{
    private readonly ICityRepository _repository;

    public GetAllCityHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<City>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllCitiesAsync())!;
}