namespace Application.Services.CustomerService.Commands;

public class CreateCustomerCommand : IRequest<Customer>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDayDate { get; set; }
    public string Email { get; set; }
    public Ulid PhoneNumberId { get; set; }
    public Ulid AddressId { get; set; }
    public Ulid CityId { get; set; }
    public Ulid NoteId { get; set; }
    public Ulid ProvinceId { get; set; }
    public Ulid CountryId { get; set; }
    public Ulid WishProductId { get; set; }
    public Ulid ProfileImageId { get; set; }
    public Ulid BusinessId { get; set; }
    public Ulid CustomerRepresentativeHistoryId { get; set; }
    public Ulid MoarefId { get; set; }
    public Ulid CategoryId { get; set; }
    public byte CustomerState { get; set; }
    public byte IsDeleted { get; set; }
    public byte Gender { get; set; }
}