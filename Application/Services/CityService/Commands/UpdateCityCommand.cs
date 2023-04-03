namespace Application.Services.CityService.Commands;

public struct UpdateCityCommand : IRequest<City>
{
    public Ulid CityId { get; set; }
    public string CityName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid ProvinceId { get; set; }
    public Ulid CustomerId { get; set; }
}