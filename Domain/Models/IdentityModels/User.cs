namespace Domain.Models.IdentityModels;

public class User : IdentityUser
{
    public User()
    {
        UserStatusType = StatusType.Show;
        CreatedOn = DateTime.UtcNow;
        
        Customers = new HashSet<Customer>();
        CustomersAdded = new HashSet<Customer>();
        CustomersUpdated = new HashSet<Customer>();

        CustomerNotesAdded = new HashSet<CustomerNote>();
        CustomerNotesUpdated = new HashSet<CustomerNote>();

        ForooshOrdersAdded = new HashSet<ForooshOrder>();
        ForooshOrdersUpdated = new HashSet<ForooshOrder>();

        ForooshFactorsAdded = new HashSet<ForooshFactor>();
        ForooshFactorsUpdated = new HashSet<ForooshFactor>();

        PeyGiryCategories = new HashSet<PeyGiryCategory>();
        PeyGiryCategoriesAdded = new HashSet<PeyGiryCategory>();
        PeyGiryCategoriesUpdated = new HashSet<PeyGiryCategory>();

        CustomerPeyGiriesAdded = new HashSet<CustomerPeyGiry>();
        CustomerPeyGiriesUpdated = new HashSet<CustomerPeyGiry>();

        // NotificationAdded = new HashSet<Notif>();
        // NotificationUpdated = new HashSet<Notif>();
        // Notifications = new HashSet<Notif>();
        
        AttributeAdded = new HashSet<Attribute>();
        AttributeUpdated = new HashSet<Attribute>();


        CustomerFeedbacks = new HashSet<CustomerFeedback>();
        CustomerFeedbacksAdded = new HashSet<CustomerFeedback>();
        CustomerFeedbacksUpdated = new HashSet<CustomerFeedback>();

        CustomerFeedbackCategories = new HashSet<CustomerFeedbackCategory>();
        CustomerFeedbackCategoryAdded = new HashSet<CustomerFeedbackCategory>();
        CustomerFeedbackCategoryUpdated = new HashSet<CustomerFeedbackCategory>();
        
        Logs = new HashSet<Log>();
        
        GroupAdded = new HashSet<UserGroup>();
        GroupUpdated = new HashSet<UserGroup>();
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
    public StatusType UserStatusType { get; set; }
    public string? Token { get; set; }// JWT Token


    public required Ulid IdBusiness { get; set; }
    public Business IdBusinessNavigation { get; set; }

    public IEnumerable<Log>? Logs { get; set; }
    
    public Ulid? IdGroup { get; set; }
    public UserGroup IdGroupNavigation { get; set; }
    public IEnumerable<UserGroup>? GroupAdded { get; set; }
    public IEnumerable<UserGroup>? GroupUpdated{ get; set; }


    public IEnumerable<Customer>? Customers { get; }
    public IEnumerable<Customer>? CustomersAdded { get; }
    public IEnumerable<Customer>? CustomersUpdated { get; }


    public IEnumerable<CustomerNote>? CustomerNotesAdded { get; }
    public IEnumerable<CustomerNote>? CustomerNotesUpdated { get; }


    public IEnumerable<CustomerPeyGiry>? CustomerPeyGiriesAdded { get; }
    public IEnumerable<CustomerPeyGiry>? CustomerPeyGiriesUpdated { get; }
    
    public IEnumerable<Notif>? NotificationAdded { get; }
    public IEnumerable<Notif>? NotificationUpdated { get; }
    public IEnumerable<Notif>? Notifications { get; }

    public IEnumerable<ForooshFactor>? ForooshFactorsAdded { get; }
    public IEnumerable<ForooshFactor>? ForooshFactorsUpdated { get; }

    public IEnumerable<ForooshOrder>? ForooshOrdersAdded { get; }
    public IEnumerable<ForooshOrder>? ForooshOrdersUpdated { get; }

    public IEnumerable<Attribute>? AttributeAdded { get; }
    public IEnumerable<Attribute>? AttributeUpdated { get; }

    public IEnumerable<PeyGiryCategory>? PeyGiryCategories { get; }
    public IEnumerable<PeyGiryCategory>? PeyGiryCategoriesAdded { get; }
    public IEnumerable<PeyGiryCategory>? PeyGiryCategoriesUpdated { get; }

    public IEnumerable<CustomerFeedback>? CustomerFeedbacks { get; }
    public IEnumerable<CustomerFeedback>? CustomerFeedbacksAdded { get; }
    public IEnumerable<CustomerFeedback>? CustomerFeedbacksUpdated { get; }

    public IEnumerable<CustomerFeedbackCategory>? CustomerFeedbackCategories { get; }
    public IEnumerable<CustomerFeedbackCategory>? CustomerFeedbackCategoryAdded { get; }
    public IEnumerable<CustomerFeedbackCategory>? CustomerFeedbackCategoryUpdated { get; }

    // public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }  
    // public ICollection<Plan>? Plans { get; set; }  
    // public ICollection<CustomerCategory>? CustomerCategories { get; set; }
    // public ICollection<Business>? Businesses { get; set; }
    // public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }
    // public ICollection<PeyGiryAttachment>? PeyGiryAttachments { get; set; }
    // public ICollection<CustomerNote>? CustomerNotes { get; set; }
    // public ICollection<CustomerNoteHashTag>? NoteHashTags{ get; set; }
}