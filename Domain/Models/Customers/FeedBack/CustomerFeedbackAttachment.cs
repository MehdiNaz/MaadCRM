namespace Domain.Models.Customers.FeedBack;

public sealed class CustomerFeedbackAttachment : BaseEntity
{
    public CustomerFeedbackAttachment()
    {
        Id = Ulid.NewUlid();
        CustomerFeedbackAttachmentStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public required string Name { get; set; }
    public required byte[] FileName { get; set; }
    public string Extenstion { get; set; }
    public Status CustomerFeedbackAttachmentStatus { get; set; }
    
    public Ulid IdCustomerFeedback { get; set; }
    public CustomerFeedback? IdCustomerFeedbackNavigation { get; set; }
}