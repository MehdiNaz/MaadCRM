namespace Application.Responses;

public struct CustomerResponse
{
    public Ulid IdCustomer { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Ulid? IdCity { get; set; }
    public Ulid? IdProvince { get; set; }
    public string? ProvinceName { get; set; }

    public string? CityName { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid? CustomerCategoryId { get; set; }
    public StatusType? CustomerStatusType { get; set; }
    public CustomerStateTypes? CustomerStateType { get; set; }
    public DateTime? From { get; set; }
    public DateTime? UpTo { get; set; }
    public Ulid? MoshtaryMoAref { get; set; }
    public string? MoarefFullName { get; set; }
    public string? MoarefPhoneNumber { get; set; }
    public Ulid? IdProduct { get; set; }
    public string? ProductName { get; set; }
    public string? IdUser { get; set; }

    public DateTime? DateCreated { get; set; }
    // public Ulid? ProductCustomerFavorite { get; set; }
    //public GenderTypes? Gender { get; set; }
    //public Ulid? IdCity { get; set; }
    //public Ulid? IdProvince { get; set; }
    
    public List<AttributeCustomerResponse>? Attributes { get; set; }
}