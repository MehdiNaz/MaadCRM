namespace Domain.Models.Customers;

public partial class Customer : BaseEntityWithUserId
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
    // public Ulid Id { get; set; }
    public GenderTypes? Gender { get; set; }
    public Status CustomerStatus { get; set; }
    public CustomerStateTypes CustomerState { get; set; }
    public CustomerActivationStatus CustomerActivationStatus { get; set; }

    // public Ulid? CustomerCategoryId { get; set; }

    // public virtual string CreatedBy { get; set; }
    // public virtual string UpdatedBy { get; set; }
    //public virtual User User { get; set; }

    public Ulid? CustomerMoarefId { get; set; }
    public virtual Customer? CustomerMoaref { get; set; }
    public virtual ICollection<Customer>? CustomerMoarefs { get; set; }

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

    public virtual ICollection<CustomersEmailAddress>? EmailAddresses { get; }
    public virtual ICollection<CustomersPhoneNumber>? PhoneNumbers { get; }
    public virtual ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; }
    public virtual ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; }
    public virtual ICollection<CustomerAddress>? CustomerAddresses { get; }
    public virtual ICollection<CustomerNote>? CustomerNotes { get; }

    public virtual ICollection<ForooshFactor>? ForooshFactors { get; }


    #region Old Relations
    // public virtual ICollection<Customer>? CustomersMoaref { get; set; }
    // public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
    // public ICollection<CustomerSubmission> CustomerSubmission { get; set; }
    // public ICollection<CustomerActivity> CustomerActivities { get; set; }
    // public ICollection<CustomerFeedbackHistory> CustomerFeedbackHistory { get; set; }
    #endregion



    public uint Version { get; set; }
}