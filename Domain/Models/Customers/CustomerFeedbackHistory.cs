namespace Domain.Models.Customers;

public class CustomerFeedbackHistory : BaseEntity
{
    public Ulid CustomerFeedbackHistoryId { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid CustomerFeedbackId { get; set; }
    public string Description { get; set; }
    public bool IsActivePoint { get; set; }

    //[ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    //[ForeignKey(nameof(CustomerFeedbackId))]
    public CustomerFeedback CustomerFeedback { get; set; }
}