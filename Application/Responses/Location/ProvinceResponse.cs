namespace Application.Responses.Location;

public struct ProvinceResponse
{
    public Ulid IdProvince { get; set; }
    public string ProvinceName { get; set; }
    public uint DisplayOrder { get; set; }
}
