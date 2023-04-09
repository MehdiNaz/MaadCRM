namespace Application.Services.CityService.Commands;

public struct CreateCityCommand : IRequest<City>
{
    public string CityName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid ProvinceId { get; set; }
}