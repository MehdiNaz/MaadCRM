using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Customers;

namespace Domain.Models.General;

public class PhoneNubmer:BaseEntity
{
    public string PhoneNumber { get; set; }
    public int PhoneType { get; set; }
    public int CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }
}