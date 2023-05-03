namespace Domain.Models.Customers.FeedBack;

public class CustomerFeedbackCategory : BaseEntityWithUserUpdate
{
    public CustomerFeedbackCategory()
    {
        Id = Ulid.NewUlid();
        CustomerFeedbackCategoryStatus = Status.Show;
        Feedbacks = new HashSet<CustomerFeedback>();
    }

    public Ulid Id { get; set; }
    public required string Name { get; set; }
    public FeedbackType TypeFeedback { get; set; }
    public bool PositiveNegative { get; set; }
    public Status CustomerFeedbackCategoryStatus { get; set; }

    public Ulid IdBusiness { get; set; }
    public Business IdBusinessNavigation { get; set; }

    public ICollection<CustomerFeedback>? Feedbacks; 
}