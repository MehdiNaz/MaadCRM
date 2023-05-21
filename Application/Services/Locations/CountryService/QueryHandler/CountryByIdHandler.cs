using Application.Responses.Location;

namespace Application.Services.Locations.CountryService.QueryHandler;

public readonly struct CountryByIdHandler : IRequestHandler<GetCountryByIdQuery, Result<CountryResponse>>
{
    private readonly ICountryRepository _repository;

    public CountryByIdHandler(ICountryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CountryResponse>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCityByIdAsync(request.CountryId))
                .Match(result => new Result<CountryResponse>(result),
                    exception => new Result<CountryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CountryResponse>(new Exception(e.Message));
        }
    }
}