namespace Domain.Models.Customers.PeyGiry;

public class CustomerPeyGiry : BaseEntity
{
    public CustomerPeyGiry()
    {
        CustomerPeyGiryId = Ulid.NewUlid();
        CustomerPeyGiryStatus = Status.Show;
    }

    public Ulid CustomerPeyGiryId { get; set; }
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomerPeyGiryStatus { get; set; }

    public Customer Customer { get; set; }
    public ICollection<PeyGiryAttachment> PeyGiryAttachments { get; set; }
}