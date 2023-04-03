namespace Application.Services.CityService.QueryHandler;

public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, City>
{
    private readonly ICityRepository _repository;

    public GetCityByIdHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<City> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetCityByIdAsync(request.CityId))!;
}