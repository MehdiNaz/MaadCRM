namespace Domain.Models.Businesses;

public class Business : BaseEntity
{
    public Business()
    {
        Id = Ulid.NewUlid();
        StatusBusiness = Status.Show;
        DisplayOrder = 0;
        CustomerNoteHashTables = new HashSet<CustomerNoteHashTable>();
        ProductCategories = new HashSet<ProductCategory>();
    }

    public Ulid Id { get; set; }
    public string BusinessName { get; set; }
    public string? Url { get; set; }
    public string? Hosts { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyAddress { get; set; }
    public int? DisplayOrder { get; set; }

    public Status StatusBusiness { get; set; }

    public virtual ICollection<CustomerNoteHashTable>? CustomerNoteHashTables { get; set; }
    public virtual ICollection<ProductCategory>? ProductCategories { get; set; }

    //public Ulid? AttributeOptionsValueId { get; set; }
    //public Ulid? BusinessAttributeId { get; set; }
    // public ICollection<User>? Users { get; set; }
    // public ICollection<Contact>? Contacts { get; set; }
    // public ICollection<ContactGroup>? ContactGroups { get; set; }
    // public ICollection<AttributeOption>? AttributeOptions { get; set; }
    // public ICollection<AttributeOptionsValue>? AttributeOptionsValues { get; set; }
    //public BusinessAttribute BusinessAttribute { get; set; }
    //public CategoryAttribute CategoryAttribute { get; set; }

    // public ICollection<Setting>? Setting { get; set; }
    // public ICollection<CategoryAttribute>? CategoryAttributes { get; set; }
    // public ICollection<BusinessPlan>? BusinessPlans { get; set; }
    // public ICollection<Customer>? Customers { get; set; }                        
}