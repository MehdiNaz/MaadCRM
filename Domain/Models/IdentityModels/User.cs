﻿namespace Domain.Models.IdentityModels;

public class User : IdentityUser
{
    public User()
    {
        Status = StatusType.Show;
        CreatedOn = DateTime.UtcNow;
        Permission = UserPermissionType.Self;
        
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
        CustomerPeyGiries = new HashSet<CustomerPeyGiry>();

        NotificationAdded = new HashSet<Notif>();
        NotificationUpdated = new HashSet<Notif>();
        Notifications = new HashSet<Notif>();
        
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

        PlansAdded = new HashSet<Plan>();
        PlansUpdated = new HashSet<Plan>();

        Pardakhts = new HashSet<Pardakht>();
        PardakhtsAdded = new HashSet<Pardakht>();
        PardakhtsUpdated = new HashSet<Pardakht>();

        TakhfifsAdded = new HashSet<Takhfif>();
        TakhfifsUpdated = new HashSet<Takhfif>();
    
        PardakhtTakhfifsAdded = new HashSet<PardakhtTakhfif>();
        PardakhtTakhfifsUpdated = new HashSet<PardakhtTakhfif>();
        
        BusinessPlans = new HashSet<BusinessPlan>();
        BusinessPlansAdded = new HashSet<BusinessPlan>();
        BusinessPlansUpdated = new HashSet<BusinessPlan>();
    }

    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? CodeMelli { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public Married? Married { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderTypes? Gender { get; set; }
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
    public StatusType Status { get; set; }
    public string? Token { get; set; }// JWT Token
    public UserPermissionType Permission { get; set; }

    public Ulid? IdCity { get; set; }
    public City? IdCityNavigation { get; set; }
    
    public required Ulid IdBusiness { get; set; }
    public Business IdBusinessNavigation { get; set; }

    public IEnumerable<Log>? Logs { get; set; }
    
    public Ulid? IdGroup { get; set; }
    public UserGroup? IdGroupNavigation { get; set; }
    public IEnumerable<UserGroup>? GroupAdded { get; set; }
    public IEnumerable<UserGroup>? GroupUpdated{ get; set; }


    public IEnumerable<Customer>? Customers { get; }
    public IEnumerable<Customer>? CustomersAdded { get; }
    public IEnumerable<Customer>? CustomersUpdated { get; }


    public IEnumerable<CustomerNote>? CustomerNotesAdded { get; }
    public IEnumerable<CustomerNote>? CustomerNotesUpdated { get; }


    public IEnumerable<CustomerPeyGiry>? CustomerPeyGiries { get; }
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
    
    
    public IEnumerable<Plan>? PlansAdded { get; }
    public IEnumerable<Plan>? PlansUpdated { get; }
    
    
    public IEnumerable<Pardakht>? Pardakhts { get; }
    public IEnumerable<Pardakht>? PardakhtsAdded { get; }
    public IEnumerable<Pardakht>? PardakhtsUpdated { get; }
    
    public IEnumerable<Takhfif>? TakhfifsAdded { get; }
    public IEnumerable<Takhfif>? TakhfifsUpdated { get; }
    
    public IEnumerable<PardakhtTakhfif>? PardakhtTakhfifsAdded { get; }
    public IEnumerable<PardakhtTakhfif>? PardakhtTakhfifsUpdated { get; }
    
    public IEnumerable<BusinessPlan>? BusinessPlans { get; }
    public IEnumerable<BusinessPlan>? BusinessPlansAdded { get; }
    public IEnumerable<BusinessPlan>? BusinessPlansUpdated { get; }
}