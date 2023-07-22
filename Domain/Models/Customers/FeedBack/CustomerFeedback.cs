namespace Domain.Models.Customers.FeedBack;

public class CustomerFeedback : BaseEntityWithOptionalUserId
{
    public CustomerFeedback()
    {
        Id = Ulid.NewUlid();
        CustomerFeedbackStatusType = StatusType.Show;
        Attachments = new HashSet<CustomerFeedbackAttachment>();
        Logs = new HashSet<Log>();
    }

    public Ulid Id { get; set; }
    public string? Description { get; set; }
    public StatusType CustomerFeedbackStatusType { get; set; }

    public Ulid IdCategory { get; set; }
    public CustomerFeedbackCategory? IdCategoryNavigation { get; set; }

    public Ulid? IdProduct { get; set; }
    public Product? IdProductNavigation { get; set; }

    public Ulid? IdCustomer { get; set; }
    public Customer? IdCustomerNavigation { get; set; }

    public ICollection<CustomerFeedbackAttachment>? Attachments;
    public ICollection<Log>? Logs;
}