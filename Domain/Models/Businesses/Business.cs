using System.Collections;

namespace Domain.Models.Businesses;

public class Business : BaseEntity
{
    public Business()
    {
        Id = Ulid.NewUlid();
        StatusTypeBusiness = StatusType.Show;
        DisplayOrder = 0;
        CustomerNoteHashTables = new HashSet<CustomerNoteHashTable>();
        ProductCategories = new HashSet<ProductCategory>();
        CustomerFeedbackCategories = new HashSet<CustomerFeedbackCategory>();
        Attributes = new HashSet<Attribute>();
        PeyGiryCategories = new HashSet<PeyGiryCategory>();
        Pardakhts = new HashSet<Pardakht>();
        BusinessPlans = new HashSet<BusinessPlan>();
    }

    public Ulid Id { get; set; }
    public string BusinessName { get; set; }
    public string? Url { get; set; }
    public string? Hosts { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyAddress { get; set; }
    public int? DisplayOrder { get; set; }

    public StatusType StatusTypeBusiness { get; set; }


    public virtual ICollection<CustomerNoteHashTable>? CustomerNoteHashTables { get; set; }
    public virtual ICollection<ProductCategory>? ProductCategories { get; set; }

    public virtual ICollection<User>? Users { get; set; }

    public virtual ICollection<CustomerFeedbackCategory>? CustomerFeedbackCategories { get; set; }
    public virtual ICollection<Attribute>? Attributes { get; set; }
    public virtual ICollection<PeyGiryCategory>? PeyGiryCategories { get; set; }

    public virtual ICollection<UserGroup>? UserGroups { get; set; }

    public virtual ICollection<BusinessPlan>? BusinessPlans { get; set; }
    public virtual ICollection<Pardakht>? Pardakhts { get; set; }
}