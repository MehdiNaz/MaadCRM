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
    //[ForeignKey(nameof(UserId))]

    public ApplicationUser User { get; set; }
    public ICollection<Setting> Setting { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
}