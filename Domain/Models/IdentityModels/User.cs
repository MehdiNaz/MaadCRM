namespace Domain.Models.IdentityModels;

public class User : IdentityUser
{
    public User()
    {
        UserStatus = Status.Show;

        Customers = new HashSet<Customer>();
        CustomersAdded = new HashSet<Customer>();
        CustomersUpdated = new HashSet<Customer>();

        CustomerNotesAdded = new HashSet<CustomerNote>();
        CustomerNotesUpdated = new HashSet<CustomerNote>();

        CustomerPeyGiriesAdded = new HashSet<CustomerPeyGiry>();
        CustomerPeyGiriesUpdated = new HashSet<CustomerPeyGiry>();
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
    public string Token { get; set; }// JWT Token


    public Ulid IdBusiness { get; set; }
    public Business IdBusinessNavigation { get; set; }

    // public Business Business { get; set; }
    // public City? City { get; set; }
    //public ICollection<Business>? Businesses { get; set; }
    // public ICollection<CustomerSubmission>? CustomerSubmissions { get; set; }
    //public ICollection<ActivityLog> ActivityLogs { get; set; }
    //public ICollection<Notification> Notifications { get; set; }
    public ICollection<Log>? Logs { get; }
    // public ICollection<SanAt>? SanAts { get; set; }
    public virtual ICollection<Customer> Customers { get; }
    public virtual ICollection<Customer> CustomersAdded { get; }
    public virtual ICollection<Customer> CustomersUpdated { get; }


    public virtual ICollection<CustomerNote> CustomerNotesAdded { get; }
    public virtual ICollection<CustomerNote> CustomerNotesUpdated { get; }


    public virtual ICollection<CustomerPeyGiry> CustomerPeyGiriesAdded { get; }
    public virtual ICollection<CustomerPeyGiry> CustomerPeyGiriesUpdated { get; }


    // public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }  
    // public ICollection<Plan>? Plans { get; set; }  
    // public ICollection<CustomerCategory>? CustomerCategories { get; set; }
    // public ICollection<Business>? Businesses { get; set; }
    // public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }
    // public ICollection<PeyGiryAttachment>? PeyGiryAttachments { get; set; }
    // public ICollection<CustomerNote>? CustomerNotes { get; set; }
    // public ICollection<CustomerNoteHashTag>? NoteHashTags{ get; set; }
}