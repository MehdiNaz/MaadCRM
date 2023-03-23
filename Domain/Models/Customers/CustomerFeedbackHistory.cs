using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Customers;

public class CustomerFeedbackHistory : BaseEntity
{
    public int CustomerId { get; set; }
    public int CustomerFeedbackId { get; set; }
    public string Description { get; set; }
    public bool IsAvtivePoint { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    [ForeignKey(nameof(CustomerFeedbackId))]
    public CustomerFeedback CustomerFeedback { get; set; }
}