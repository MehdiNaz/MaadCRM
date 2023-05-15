namespace Application.Responses;

public struct CityResponse
{
    public Ulid IdCity { get; set; }
    public string CityName { get; set; }
    public Ulid IdProvince { get; set; }
    public string ProvinceName { get; set; }
    public uint DisplayOrder { get; set; }
}
