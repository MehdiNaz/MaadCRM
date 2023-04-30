namespace Application.Services.Locations.CityService.Queries;

public struct CityByIdQuery : IRequest<Result<CityResponse>>
{
    public Ulid CityId { get; set; }
}