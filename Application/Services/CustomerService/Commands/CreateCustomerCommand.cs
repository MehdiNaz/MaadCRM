namespace Application.Services.CustomerService.Commands;

public struct CreateCustomerCommand : IRequest<Customer?>
{
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public byte[]? CustomerPic { get; set; }
    //public required string UserId { get; set; }
    //public required string CreatedBy { get; set; }
    //public required string UpdatedBy { get; set; }
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
}