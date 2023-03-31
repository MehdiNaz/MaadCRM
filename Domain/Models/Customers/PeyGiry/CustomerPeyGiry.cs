namespace Domain.Models.Customers.PeyGiry;

public class CustomerPeyGiry : BaseEntity
{
    public CustomerPeyGiry()
    {
        IsDeleted = Status.NotDeleted;
    }

    public Ulid CustomerPeyGiryId { get; set; }
    public string Description { get; set; }
    public Status IsDeleted { get; set; }
    public Ulid CustomerId { get; set; }

    public Customer Customer { get; set; }
    public ICollection<PeyGiryAttachment> PeyGiryAttachments { get; set; }
}