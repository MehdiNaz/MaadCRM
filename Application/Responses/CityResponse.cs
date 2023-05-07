namespace Application.Responses;

public struct CityResponse
{
    public Ulid CityId { get; set; }
    public string CityName { get; set; }
    public Ulid ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public uint DisplayOrder { get; set; }
}
