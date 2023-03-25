namespace Domain.Models.Customers;

public class CustomerSubmission : BaseEntity
{
    public Ulid CustomerSubmissionId { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid UserId { get; set; }
    public DateTime? FollowDateTime { get; set; }


    //[ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    //[ForeignKey(nameof(UserId))]
    public ApplicationUser Users { get; set; }
}