namespace Domain.Models.Customers;

public class Customer : BaseEntity
{
    public Ulid CustomerId { get; set; }
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










    //[ForeignKey(nameof(BusinessId))]
    public Business Business { get; set; }
    public Moaref Moaref { get; set; }
    public CustomersCategories CustomersCategories{ get; set; }
    public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
    public ICollection<PhoneNumber> PhoneNubmers { get; set; }
    public ICollection<Address.Address> Addresses { get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<CustomerSubmission> CustomerSubmission { get; set; }
    public ICollection<CustomerActivityHistory> CustomerActivityHistorys { get; set; }
    public ICollection<CustomerFeedbackHistory> CustomerFeedbackHistory { get; set; }
    //[InverseProperty(nameof(CustomerRepresentativeHistory.Customers))]
    public ICollection<CustomerRepresentativeHistory> CustomerRepresentativeHistory2 { get; set; }
    //[InverseProperty(nameof(CustomerRepresentativeHistory.CustomerRepresentative))]
    public ICollection<CustomerRepresentativeHistory> CustomerRepresentativeHistory3 { get; set; }
}