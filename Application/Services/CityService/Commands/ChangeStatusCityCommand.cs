namespace Application.Services.CityService.Commands;

public struct ChangeStatusCityCommand : IRequest<City?>
{
    public Ulid CityId { get; set; }
    public Status CityStatus { get; set; }
}