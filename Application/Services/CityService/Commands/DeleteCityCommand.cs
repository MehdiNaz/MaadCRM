namespace Application.Services.CityService.Commands;

public struct DeleteCityCommand : IRequest<City>
{
    public Ulid CityId { get; set; }
}