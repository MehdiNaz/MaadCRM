using Application.Responses.Location;

namespace Application.Services.Locations.ProvinceService.Queries;

public struct GetAllProvincesQuery : IRequest<Result<ICollection<ProvinceResponse>>>
{
}