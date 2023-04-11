namespace Application.Services.CityService.QueryHandler;

public readonly struct GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, City>
{
    private readonly ICityRepository _repository;

    public GetCityByIdHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<City> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetCityByIdAsync(request.CityId))!;
}