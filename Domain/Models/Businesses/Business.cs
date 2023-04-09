namespace Domain.Models.Businesses;

public class Business : BaseEntityWithUpdateInfo
{
    public Business()
    {
        BusinessId = Ulid.NewUlid();
        BusinessStatus = Status.Show;
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
    public int? DisplayOrder { get; set; } = 0;
    //public Ulid? CustomerId { get; set; }
    //public Ulid? ContactId { get; set; }
    //public Ulid? ContactGroupId { get; set; }
    //public Ulid? AttributeOptionsValueId { get; set; }
    //public Ulid? BusinessAttributeId { get; set; }
    public Status BusinessStatus { get; set; }


    public ICollection<User>? Users { get; set; }                                   //Relation OK
    public ICollection<Contact>? Contacts { get; set; }                            //Relation OK
    public ICollection<ContactGroup>? ContactGroups { get; set; }                  //Relation OK
    public ICollection<AttributeOptions>? AttributeOptions { get; set; }           //Relation OK
    public ICollection<AttributeOptionsValue>? AttributeOptionsValues { get; set; }//Relation OK
    //public BusinessAttribute BusinessAttribute { get; set; }
    //public CategoryAttribute CategoryAttribute { get; set; }

    public ICollection<Setting>? Setting { get; set; }
    public ICollection<CategoryAttribute>? CategoryAttributes { get; set; }
    public ICollection<BusinessPlans>? BusinessPlans { get; set; }                 //Relation OK
    public ICollection<Customer> Customers { get; set; }                           //Relation OK
    public ICollection<User>? Users { get; set; }
}