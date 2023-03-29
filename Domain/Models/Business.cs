namespace Domain.Models;

public class Business : BaseEntity
{
    public Ulid BusinessId { get; set; }
    public string BusinessName { get; set; }
    public string Url { get; set; }
    public string Hosts { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public bool SslEnabled { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public Ulid UserId { get; set; }
    public Ulid CustomerId { get; set; }
    //[ForeignKey(nameof(UserId))]

    public ApplicationUser User { get; set; }
    public Customer Customer { get; set; }
    public ContactGroup ContactGroup{ get; set; }
    public ICollection<Setting> Setting { get; set; }
    public ICollection<Contact> Contacts{ get; set; }
    public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
}