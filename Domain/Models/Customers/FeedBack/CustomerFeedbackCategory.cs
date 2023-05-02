namespace Domain.Models.Customers.FeedBack;

public class CustomerFeedbackCategory : BaseEntityWithUserUpdate
{
    public CustomerFeedbackCategory()
    {
        Id = Ulid.NewUlid();
        Status = Status.Show;
        Feedbacks = new HashSet<CustomerFeedback>();
    }

    public Ulid Id { get; set; }
    public required string Name { get; set; }
    public FeedbackType TypeFeedback { get; set; }
    public bool PositiveNegative { get; set; }
    public Status Status { get; set; }

    public Ulid IdBusiness { get; set; }
    public Business IdBusinessNavigation { get; set; }

    public ICollection<CustomerFeedback>? Feedbacks; 
}