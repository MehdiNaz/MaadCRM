namespace Application.Responses.TeamMate;

public struct TeamMateResponse
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Email { get; set; }
    public string? CodeMelli { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public Married? Married { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid? IdCity { get; set; }
    public string CityName { get; set; }
    public Ulid IdProvince { get; set; }
    public string ProvinceName { get; set; }
    public string? PhoneNo { get; set; }
    public Ulid? IdGroup { get; set; }
    public string GroupTitle { get; set; }
    public DateTime? CreatedOn { get; set; }
}