namespace Application.Services.Customer.CustomerService.Commands;

public struct CreateCustomerCommand : IRequest<Result<CustomerResponse>>
{
    public string? FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public byte[]? CustomerPic { get; set; }
    public string UserId { get; set; }
    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
    public Ulid? CityId { get; set; }
    public Ulid? CustomerCategoryId { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid? CustomerMoarefId { get; set; }
    public ICollection<string>? PhoneNumbers { get; set; }
    public ICollection<string>? EmailAddresses { get; set; }
    public ICollection<Ulid>? FavoritesLists { get; set; }
    public ICollection<string>? CustomersAddresses { get; set; }
    public ICollection<string>? CustomerNotes { get; set; }
    public ICollection<string>? CustomerPeyGiries { get; set; }
    
    public List<AttributeCustomerValueRequest>? AttributesValue { get; set; }

}