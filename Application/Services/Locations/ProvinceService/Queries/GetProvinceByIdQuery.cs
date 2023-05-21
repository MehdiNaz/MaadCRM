using Application.Responses.Location;

namespace Application.Services.Locations.ProvinceService.Queries;

public struct GetProvinceByIdQuery : IRequest<Result<ProvinceResponse>>
{
    public Ulid ProvinceId { get; set; }
}