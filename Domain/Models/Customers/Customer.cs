namespace Domain.Models.Customers;

public class Customer : BaseEntity
{
    public Customer()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDayDate { get; set; }
    public Ulid EmailId { get; set; }
    public Ulid PhoneNumberId { get; set; }
    public Ulid AddressId { get; set; }
    public Ulid CityId { get; set; }
    public Ulid NoteId { get; set; }
    public Ulid ProvinceId { get; set; }
    public Ulid CountryId { get; set; }
    public Ulid WishProductId { get; set; }
    public Ulid ProfileImageId { get; set; }
    public Ulid CategoryId { get; set; }
    public Ulid BusinessId { get; set; }
    public Ulid FavoritesListId{ get; set; }
    public byte CustomerStatues { get; set; }
    public Status IsDeleted { get; set; }
    public GenderTypes Gender { get; set; }
    public ShowTypes IsShown { get; set; }
    public string InsertedBy { get; set; }
    public string UpdatedBy { get; set; }

    #region Moaref
    public Ulid CustomerMoarefId { get; set; }
    public Customer CustomerMoarf { get; set; }
    public ICollection<Customer> CustomersMoarf { get; set; }
    #endregion

    public User User { get; set; }
    //[ForeignKey(nameof(BusinessId))]
    public CustomersEmailAddress EmailAddress { get; set; }
    public CustomersPhoneNumber PhoneNumber { get; set; }
    public CustCategory CustCategory { get; set; }
    public ProductCustomerFavoritesList ProductCustomerFavoritesList { get; set; }
    public ICollection<Business> Businesses { get; set; }
    public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
    public ICollection<Address.Address> Addresses { get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<CustomerSubmission> CustomerSubmission { get; set; }
    public ICollection<CustomerActivity> CustomerActivities { get; set; }
    public ICollection<CustomerActivityHistory> CustomerActivityHistorys { get; set; }
    public ICollection<CustomerFeedbackHistory> CustomerFeedbackHistory { get; set; }
    //[InverseProperty(nameof(CustomerRepresentativeHistory.Customers))]
    public ICollection<CustomerRepresentativeHistory> CustomerRepresentativeHistory2 { get; set; }
    //[InverseProperty(nameof(CustomerRepresentativeHistory.CustomerRepresentative))]
    public ICollection<CustomerRepresentativeHistory> CustomerRepresentativeHistory3 { get; set; }
    public ICollection<City> Cities{ get; set; }
}