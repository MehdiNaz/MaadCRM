using Application.Responses.Location;

namespace Application.Services.Locations.CountryService.Queries;

public struct GetAllCountriesQuery : IRequest<Result<ICollection<CountryResponse>>>
{
}