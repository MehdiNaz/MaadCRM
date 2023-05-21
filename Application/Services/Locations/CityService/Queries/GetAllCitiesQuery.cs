using Application.Responses.Location;

namespace Application.Services.Locations.CityService.Queries;

public struct GetAllCitiesQuery : IRequest<Result<ICollection<CityResponse>>>
{
}