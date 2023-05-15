namespace Application.Responses;

public struct CountryResponse
{
    public Ulid IdCountry { get; set; }
    public string CountryName { get; set; }
    public uint DisplayOrder { get; set; }
}
