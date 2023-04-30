namespace Application.Services.Locations.CityService.QueryHandler;

public readonly struct ShowCitiesByIdProvinceHandler : IRequestHandler<ShowCitiesByIdProvinceQuery, Result<ICollection<CityResponse>>>
{
    private readonly ICityRepository _repository;

    public ShowCitiesByIdProvinceHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CityResponse>>> Handle(ShowCitiesByIdProvinceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowCitiesByIdProvinceAsync(request.CityId, request.ProvinceId))
                .Match(result => new Result<ICollection<CityResponse>>(result),
                exception => new Result<ICollection<CityResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CityResponse>>(new Exception(e.Message));
        }
    }
}
