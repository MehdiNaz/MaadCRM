using Application.Responses.Location;

namespace Application.Services.Locations.CountryService.Queries;

public struct GetCountryByIdQuery : IRequest<Result<CountryResponse>>
{
    public Ulid CountryId { get; set; }
}