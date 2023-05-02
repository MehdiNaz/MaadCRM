namespace Domain.Models.IdentityModels;

public sealed class User : IdentityUser
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
        
        CustomerFeedbacks = new HashSet<CustomerFeedback>();
        CustomerFeedbacksAdded = new HashSet<CustomerFeedback>();
        CustomerFeedbacksUpdated = new HashSet<CustomerFeedback>();
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
    public Status UserStatus { get; set; }
    public string? Token { get; set; }// JWT Token


    public required Ulid IdBusiness { get; set; }
    public Business IdBusinessNavigation { get; set; }

    // public Business Business { get; set; }
    // public City? City { get; set; }
    //public ICollection<Business>? Businesses { get; set; }
    // public ICollection<CustomerSubmission>? CustomerSubmissions { get; set; }
    //public ICollection<ActivityLog> ActivityLogs { get; set; }
    //public ICollection<Notification> Notifications { get; set; }
    public IEnumerable<Log>? Logs { get; }
    // public ICollection<SanAt>? SanAts { get; set; }
    public IEnumerable<Customer>? Customers { get; }
    public IEnumerable<Customer>? CustomersAdded { get; }
    public IEnumerable<Customer>? CustomersUpdated { get; }


    public IEnumerable<CustomerNote>? CustomerNotesAdded { get; }
    public IEnumerable<CustomerNote>? CustomerNotesUpdated { get; }


    public IEnumerable<CustomerPeyGiry>? CustomerPeyGiriesAdded { get; }
    public IEnumerable<CustomerPeyGiry>? CustomerPeyGiriesUpdated { get; }
    
    public IEnumerable<CustomerFeedback>? CustomerFeedbacks { get; }
    public IEnumerable<CustomerFeedback>? CustomerFeedbacksAdded { get; }
    public IEnumerable<CustomerFeedback>? CustomerFeedbacksUpdated { get; }


    // public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }  
    // public ICollection<Plan>? Plans { get; set; }  
    // public ICollection<CustomerCategory>? CustomerCategories { get; set; }
    // public ICollection<Business>? Businesses { get; set; }
    // public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }
    // public ICollection<PeyGiryAttachment>? PeyGiryAttachments { get; set; }
    // public ICollection<CustomerNote>? CustomerNotes { get; set; }
    // public ICollection<CustomerNoteHashTag>? NoteHashTags{ get; set; }
}