namespace Domain.Models.Customers;

public class Customer : BaseEntity
{
    public Customer()
    {
        Id = Ulid.NewUlid();
        CustomerState = CustomerStateTypes.Belghoveh;
        CustomerStatus = Status.Show;
        CustomerActivationStatus = CustomerActivationStatus.Active;
    }

    public Ulid Id { get; set; }
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public byte[]? CustomerPic { get; set; }
    public Ulid? CityId { get; set; }
    // public Ulid BusinessId { get; set; }
    public Ulid? CustomerCategoryId { get; set; }
    public GenderTypes? Gender { get; set; }
    public Status CustomerStatus { get; set; }
    public CustomerStateTypes CustomerState { get; set; }
    public CustomerActivationStatus CustomerActivationStatus { get; set; }

    // public string CreatedBy { get; set; }
    // public string UpdatedBy { get; set; }
    public string UserId { get; set; }
    // public User User { get; set; }

    #region Moaref
    public Ulid? CustomerMoarefId { get; set; }
    public Customer? CustomerMoaref { get; set; }
    public ICollection<Customer>? CustomersMoaref { get; set; }
    #endregion

    // public Business Business { get; set; }                                                             
    public City? City { get; set; }                                                                    
    // public CustomerCategory CustomerCategory { get; set; }                                             
    public ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; set; }                  
    public ICollection<CustomersEmailAddress>? EmailAddresses { get; set; }                         
    public ICollection<CustomersPhoneNumber>? PhoneNumbers { get; set; }                            
    public ICollection<CustomerNote>? CustomerNotes { get; set; }                                   
    public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }                            
    public ICollection<CustomersAddress>? CustomersAddresses { get; set; }                          
    public ICollection<ForoshFactor>? ForoshFactors { get; set; }                                   

    #region Old Relations
    public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
    public ICollection<CustomerSubmission> CustomerSubmission { get; set; }
    public ICollection<CustomerActivity> CustomerActivities { get; set; }
    public ICollection<CustomerFeedbackHistory> CustomerFeedbackHistory { get; set; }
    #endregion
}