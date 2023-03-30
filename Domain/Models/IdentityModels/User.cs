namespace Domain.Models.IdentityModels;

public class User : IdentityUser<string>
{
    public User()
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? CodeMelli { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public Married? Married { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid CityId { get; set; }
    //public int? Points { get; set; }
    public int? LoginCount { get; set; }
    public DateTime? LastLogin { get; set; }
    public string? UserAgent { get; set; }
    public string? LastIp { get; set; }
    public byte? Flag { get; set; }
    public bool? Limited { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string WebSite { get; set; }
    public string OtpPassword { get; set; }
    public DateTime OtpPasswordExpired { get; set; }
    public DateTimeOffset? LastLoginDate { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    //Identity : 
    public List<UserRole>? UsersRoles { get; set; }                              //OK
    public List<UserClaim>? UserClaims { get; set; }                             //OK
    public List<UserToken>? UserTokens { get; set; }                             //OK
    public List<UserLogin>? UserLogins { get; set; }                             //OK
                                                                                 
    public City City { get; set; }                                               //OK
    public ICollection<Business> Businesses { get; set; }                        //OK
    public ICollection<CustomerSubmission> CustomerSubmissions { get; set; }     //OK
    public ICollection<ActivityLog> ActivityLogs { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<Log> Logs { get; set; }
    public ICollection<SanAt> SanAts { get; set; }                               //OK
    public ICollection<Customer> Customers{ get; set; }                         //OK
}