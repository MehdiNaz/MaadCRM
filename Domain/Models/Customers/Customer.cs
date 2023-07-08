namespace Domain.Models.Customers;

public class Customer : BaseEntityWithUserId
{
    public Customer()
    {
        Id = Ulid.NewUlid();
        CustomerState = CustomerStateTypes.Belghoveh;
        CustomerStatusType = StatusType.Show;
        CustomerActivationStatus = CustomerActivationStatus.Active;
        EmailAddresses = new HashSet<CustomersEmailAddress>();
        PhoneNumbers = new HashSet<CustomersPhoneNumber>();
        CustomerNotes = new HashSet<CustomerNote>();
        CustomerPeyGiries = new HashSet<CustomerPeyGiry>();
        FavoritesLists = new HashSet<ProductCustomerFavoritesList>();
        CustomerAddresses = new HashSet<CustomerAddress>();
        ForooshFactors = new HashSet<ForooshFactor>();
        Moarefs = new HashSet<Customer>();
        CustomerFeedbacks = new HashSet<CustomerFeedback>();
        Logs = new HashSet<Log>();
        CustomerAttributes = new HashSet<AttributeCustomer>();
    }

    public Ulid Id { get; set; }
    public string? FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public byte[]? CustomerPic { get; set; }
    public GenderTypes? Gender { get; set; }
    public StatusType CustomerStatusType { get; set; }
    public CustomerStateTypes CustomerState { get; set; }
    public CustomerActivationStatus CustomerActivationStatus { get; set; }

    public Ulid? IdMoaref { get; set; }
    public virtual Customer? IdMoarefNavigation { get; set; }
    public virtual ICollection<Customer>? Moarefs { get; set; }

    public Ulid? IdCity { get; set; }
    public virtual City? IdCityNavigation { get; set; }

    public virtual ICollection<CustomersEmailAddress>? EmailAddresses { get; }

    public virtual ICollection<CustomersPhoneNumber>? PhoneNumbers { get; }

    public virtual ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; }

    public virtual ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; }

    public virtual ICollection<CustomerAddress>? CustomerAddresses { get; }

    public virtual ICollection<CustomerNote>? CustomerNotes { get; }

    public virtual ICollection<ForooshFactor>? ForooshFactors { get; }

    public virtual ICollection<CustomerFeedback>? CustomerFeedbacks { get; }

    public virtual ICollection<Log>? Logs { get; }

    public virtual ICollection<AttributeCustomer>? CustomerAttributes { get; }
}