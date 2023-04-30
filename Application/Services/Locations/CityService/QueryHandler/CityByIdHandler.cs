namespace Application.Services.Locations.CityService.QueryHandler;

public readonly struct CityByIdHandler : IRequestHandler<CityByIdQuery, Result<CityResponse>>
{
    private readonly ICityRepository _repository;

    public CityByIdHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CityResponse>> Handle(CityByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCityByIdAsync(request.CityId))
                .Match(result => new Result<CityResponse>(result),
                exception => new Result<CityResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CityResponse>(new Exception(e.Message));
        }
    }
}