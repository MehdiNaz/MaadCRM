using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Customers;

public class CustomerActivityHistory:BaseEntity
{
    public int CustomerId { get; set; }
    public int CustomerActivityId { get; set; }
    public string Description { get; set; }
    public bool IsAvtivePoint { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    [ForeignKey(nameof(CustomerActivityId))]
    public CustomerActivity CustomerActivity { get; set; }
}