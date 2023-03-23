using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Customers;
using Domain.Models.SpecialFields;
using Domain.Models.Users;

namespace Domain.Models.General;

public class Business:BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Hosts { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public bool SslEnabled { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public ICollection<Setting> Setting { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
}