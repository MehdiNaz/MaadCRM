using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Users;

namespace Domain.Models.Customers;

public class CustomerSubmission:BaseEntity
{
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public DateTime? FollowDateTime { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    [ForeignKey(nameof(UserId))]
    public User Users { get; set; }
}