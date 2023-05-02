namespace Domain.Models.Customers;

public sealed class Customer : BaseEntityWithUserId
{
    public Customer()
    {
        Id = Ulid.NewUlid();
        CustomerState = CustomerStateTypes.Belghoveh;
        CustomerStatus = Status.Show;
        CustomerActivationStatus = CustomerActivationStatus.Active;
        EmailAddresses = new HashSet<CustomersEmailAddress>();
        PhoneNumbers = new HashSet<CustomersPhoneNumber>();
        CustomerNotes = new HashSet<CustomerNote>();
        CustomerPeyGiries = new HashSet<CustomerPeyGiry>();
        FavoritesLists = new HashSet<ProductCustomerFavoritesList>();
        CustomerAddresses = new HashSet<CustomerAddress>();
        ForooshFactors = new HashSet<ForooshFactor>();
        CustomerMoarefs = new HashSet<Customer>();
    }

    public Ulid Id { get; set; }
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public byte[]? CustomerPic { get; set; }
    public GenderTypes? Gender { get; set; }
    public Status CustomerStatus { get; set; }
    public CustomerStateTypes CustomerState { get; set; }
    public CustomerActivationStatus CustomerActivationStatus { get; set; }

    public Ulid? CustomerMoarefId { get; set; }
    public Customer? CustomerMoaref { get; set; }
    public ICollection<Customer>? CustomerMoarefs { get; set; }

    // public virtual Business Business { get; set; }     
    // public virtual CustomerCategory CustomerCategory { get; set; }  

    public Ulid? IdCity { get; set; }
    public City? IdCityNavigation { get; set; }



    // public string IdUserUpdated { get; set; }
    // public virtual User IdUserUpdateNavigation { get; set; }
    //
    // public string IdUserAdded { get; set; }
    // public virtual User IdUserAddNavigation { get; set; }

    // public string IdUser { get; set; }
    // public virtual User IdUserNavigation { get; set; }

    public ICollection<CustomersEmailAddress>? EmailAddresses { get; }
    
    public ICollection<CustomersPhoneNumber>? PhoneNumbers { get; }
    
    public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; }
    
    public ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; }
    
    public ICollection<CustomerAddress>? CustomerAddresses { get; }
    
    public ICollection<CustomerNote>? CustomerNotes { get; }

    public ICollection<ForooshFactor>? ForooshFactors { get; }


    #region Old Relations
    // public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
    // public ICollection<CustomerSubmission> CustomerSubmission { get; set; }
    // public ICollection<CustomerActivity> CustomerActivities { get; set; }
    // public ICollection<CustomerFeedbackHistory> CustomerFeedbackHistory { get; set; }
    #endregion
}