namespace Domain.Models.IdentityModels;

public class User : IdentityUser
{
    public User()
    {
        UserStatus = Status.Show;
    }

    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? CodeMelli { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public Married? Married { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid? CityId { get; set; }
    public string CustomerId { get; set; }
    //public int? Points { get; set; }
    public int? LoginCount { get; set; }
    public DateTime? LastLogin { get; set; }
    public string? UserAgent { get; set; }
    public string? LastIp { get; set; }
    public byte? Flag { get; set; }
    public bool? Limited { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? WebSite { get; set; }
    public string? OtpPassword { get; set; }
    public DateTime? OtpPasswordExpired { get; set; }
    public DateTimeOffset? LastLoginDate { get; set; }
    public Ulid BusinessId { get; set; }
    public Status UserStatus { get; set; }


    public Business Business{ get; set; }
    public City? City { get; set; }
    //public ICollection<Business>? Businesses { get; set; }
    public ICollection<CustomerSubmission>? CustomerSubmissions { get; set; }
    //public ICollection<ActivityLog> ActivityLogs { get; set; }
    //public ICollection<Notification> Notifications { get; set; }
    public ICollection<Log>? Logs { get; set; }
    public ICollection<SanAt>? SanAts { get; set; }
    public ICollection<Customer>? Customers { get; set; }  //Relation OK
    public ICollection<CustomerCategory> CustomerCategories { get; set; }
    public ICollection<Plan> Plans { get; set; }

    
}