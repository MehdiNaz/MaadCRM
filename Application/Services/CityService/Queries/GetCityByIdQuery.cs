namespace Application.Services.CityService.Queries;

public struct GetCityByIdQuery : IRequest<City>
{
    public Ulid CityId { get; set; }
}