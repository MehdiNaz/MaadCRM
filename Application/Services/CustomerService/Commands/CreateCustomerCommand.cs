namespace Application.Services.CustomerService.Commands;

public struct CreateCustomerCommand : IRequest<Customer>
{
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public byte[]? CustomerPic { get; set; }
    //public required string UserId { get; set; }
    //public required string CreatedBy { get; set; }
    //public required string UpdatedBy { get; set; }
   // public Ulid? CityId { get; set; }
    public Ulid? CustomerCategoryId { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid? CustomerMoarefId { get; set; }
    public ICollection<CustomersPhoneNumber>? PhoneNumbers { get; set; }
    public ICollection<CustomersEmailAddress>? EmailAddresses { get; set; }
    public ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; set; }
    public ICollection<CustomersAddress>? CustomersAddresses { get; set; }
    public ICollection<CustomerNote>? CustomerNotes { get; set; }
    public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }
    public City? City { get; set; }
}