using Application.Responses.Location;

namespace Application.Services.Locations.CityService.Queries;

public struct ShowCitiesByIdProvinceQuery : IRequest<Result<ICollection<CityResponse>>>
{
    public Ulid CityId { get; set; }
    public Ulid ProvinceId { get; set; }
}
