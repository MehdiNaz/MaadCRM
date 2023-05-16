namespace Domain.Models.Customers;

public sealed class Customer : BaseEntityWithUserId
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
        CustomerAttributes = new HashSet<CustomerAttribute>();
    }

    public Ulid Id { get; set; }
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public byte[]? CustomerPic { get; set; }
    public GenderTypes? Gender { get; set; }
    public StatusType CustomerStatusType { get; set; }
    public CustomerStateTypes CustomerState { get; set; }
    public CustomerActivationStatus CustomerActivationStatus { get; set; }

    public Ulid? IdMoaref { get; set; }
    public Customer? IdMoarefNavigation { get; set; }
    public ICollection<Customer>? Moarefs { get; set; }

    public Ulid? IdCity { get; set; }
    public City? IdCityNavigation { get; set; }

    public ICollection<CustomersEmailAddress>? EmailAddresses { get; }

    public ICollection<CustomersPhoneNumber>? PhoneNumbers { get; }

    public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; }

    public ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; }

    public ICollection<CustomerAddress>? CustomerAddresses { get; }

    public ICollection<CustomerNote>? CustomerNotes { get; }

    public ICollection<ForooshFactor>? ForooshFactors { get; }

    public ICollection<CustomerFeedback>? CustomerFeedbacks { get; }

    public ICollection<Log>? Logs { get; }

    public ICollection<CustomerAttribute>? CustomerAttributes { get; }
}