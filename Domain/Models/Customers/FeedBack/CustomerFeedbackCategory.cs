namespace Domain.Models.Customers.FeedBack;

public class CustomerFeedbackCategory : BaseEntityWithUserId
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
    
    public ICollection<CustomerFeedback>? Feedbacks; 
}