namespace Domain.Models.Customers;

public class CustomerSubmission : BaseEntity
{
    public CustomerSubmission()
    {
        CustomerSubmissionId = Ulid.NewUlid();
    }

    public Ulid CustomerSubmissionId { get; set; }
    public Ulid CustomerId { get; set; }
    public string UserId { get; set; }
    public DateTime? FollowDateTime { get; set; }


    //[ForeignKey(nameof(Id))]
    // public Customer Customers { get; set; }
    //[ForeignKey(nameof(UserId))]
    // public User Users { get; set; }
}