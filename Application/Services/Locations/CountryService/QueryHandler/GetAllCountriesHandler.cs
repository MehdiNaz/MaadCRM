using Application.Responses.Location;

namespace Application.Services.Locations.CountryService.QueryHandler;

public readonly struct GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, Result<ICollection<CountryResponse>>>
{
    private readonly ICountryRepository _repository;

    public GetAllCountriesHandler(ICountryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CountryResponse>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCountriesAsync())
                .Match(result => new Result<ICollection<CountryResponse>>(result),
                    exception => new Result<ICollection<CountryResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CountryResponse>>(new Exception(e.Message));
        }
    }
}