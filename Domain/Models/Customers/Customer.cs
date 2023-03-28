namespace Domain.Models.Customers;

public class Customer : BaseEntity
{
    public Customer()
    {
        IsDeleted = (byte)Status.NotDeleted;
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
    public Ulid MoarefId { get; set; }
    public Ulid CategoryId { get; set; }
    public byte CustomerStatues { get; set; }
    public byte IsDeleted { get; set; }
    public byte Gender { get; set; }



    //[ForeignKey(nameof(BusinessId))]
    public Business Business { get; set; }
    public Moaref Moaref { get; set; }
    public CustomersEmailAddress EmailAddress { get; set; }
    public CustomersPhoneNumber PhoneNubmer { get; set; }
    public CustomersCategories CustomersCategories { get; set; }
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
}