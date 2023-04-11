namespace Domain.Models.Customers;

public class CustomerFeedback : BaseEntity
{
    public CustomerFeedback()
    {
        CustomerFeedbackId = Ulid.NewUlid();
        CustomerFeedbackStatus = Status.Show;
    }

    public Ulid CustomerFeedbackId { get; set; }
    public string FeedbackName { get; set; }
    public int DisplayOrder { get; set; }
    public decimal Point { get; set; }
    public int BalancePoint { get; set; }
    public Status CustomerFeedbackStatus { get; set; }


    public ICollection<CustomerFeedbackHistory>? CustomerFeedbackHistories { get; set; }
}