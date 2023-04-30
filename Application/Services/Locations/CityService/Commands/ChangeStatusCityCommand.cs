namespace Application.Services.Locations.CityService.Commands;

public struct ChangeStatusCityCommand : IRequest<Result<City>>
{
    public Ulid CityId { get; set; }
    public Status CityStatus { get; set; }
}