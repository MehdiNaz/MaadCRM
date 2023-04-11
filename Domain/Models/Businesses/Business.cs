namespace Domain.Models.Businesses;

public class Business : BaseEntity
{
    public Business()
    {
        BusinessId = Ulid.NewUlid();
        BusinessStatus = Status.Show;
        DisplayOrder = 0;
        //DateCreated = DateTime.UtcNow;
        //DateLastUpdate = DateTime.UtcNow;
    }

    public Ulid BusinessId { get; set; }
    public string BusinessName { get; set; }
    public string? Url { get; set; }
    public string? Hosts { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyAddress { get; set; }
    //public bool SslEnabled { get; set; }
    public int? DisplayOrder { get; set; } 
    //public Ulid? Id { get; set; }
    //public Ulid? ContactId { get; set; }
    //public Ulid? ContactGroupId { get; set; }
    //public Ulid? AttributeOptionsValueId { get; set; }
    //public Ulid? BusinessAttributeId { get; set; }
    public Status BusinessStatus { get; set; }


    public ICollection<User>? Users { get; set; }                                   //Relation OK
    public ICollection<Contact>? Contacts { get; set; }                            //Relation OK
    public ICollection<ContactGroup>? ContactGroups { get; set; }                  //Relation OK
    public ICollection<AttributeOption>? AttributeOptions { get; set; }           //Relation OK
    public ICollection<AttributeOptionsValue>? AttributeOptionsValues { get; set; }//Relation OK
    //public BusinessAttribute BusinessAttribute { get; set; }
    //public CategoryAttribute CategoryAttribute { get; set; }

    public ICollection<Setting>? Setting { get; set; }
    public ICollection<CategoryAttribute>? CategoryAttributes { get; set; }
    public ICollection<BusinessPlan>? BusinessPlans { get; set; }                 //Relation OK
    // public ICollection<Customer>? Customers { get; set; }                           //Relation OK
}