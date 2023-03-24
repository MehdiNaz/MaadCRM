namespace Domain.Identity;
public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? CodeMelli { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public Married? Married { get; set; }

    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public short? City { get; set; }
    public int? Points { get; set; }
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
    public ICollection<Business> Business { get; set; }
    public ICollection<CustomerSubmission> customerSubmissions { get; set; }
    public ICollection<ActivityLog> ActivityLogs { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    
    public List<Log> Logs { get; set; }
}