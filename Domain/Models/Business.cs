using Domain.UnDifined;

namespace Domain.Models;

public class Business : BaseEntity
{
    public Business()
    {
        BusinessId = Ulid.NewUlid();
    }

    public Ulid BusinessId { get; set; }
    public string BusinessName { get; set; }
    public string Url { get; set; }
    public string Hosts { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public bool SslEnabled { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public string UserId { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid ContactId { get; set; }
    public Ulid ContactGroupId { get; set; }
    public Ulid AttributeOptionsId { get; set; }
    public Ulid AttributeOptionsValueId { get; set; }
    public Ulid BusinessAttributeId { get; set; }
    //public Ulid CategoryAttributeId { get; set; }


    public User User { get; set; }
    public Contact Contact { get; set; }
    public ContactGroup ContactGroup { get; set; }
    public AttributeOptions AttributeOptions { get; set; }
    public AttributeOptionsValue AttributeOptionsValue { get; set; }
    public BusinessAttribute BusinessAttribute { get; set; }
    //public CategoryAttribute CategoryAttribute { get; set; }

    public ICollection<Setting> Setting { get; set; }
    public ICollection<CategoryAttribute> CategoryAttributes { get; set; }




    public ICollection<Customer> Customers { get; set; }                       //Relation OK
}