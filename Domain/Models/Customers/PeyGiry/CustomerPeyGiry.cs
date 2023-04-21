namespace Domain.Models.Customers.PeyGiry;

public class CustomerPeyGiry : BaseEntity
{
    public CustomerPeyGiry()
    {
        Id = Ulid.NewUlid();
        StatusCustomerPeyGiry = Status.Show;
        PeyGiryAttachments = new HashSet<PeyGiryAttachment>();
    }

    public Ulid Id { get; set; }
    public required string Description { get; set; }
    public Status StatusCustomerPeyGiry { get; set; }

    
    public required Ulid IdCustomer { get; set; }
    public virtual Customer? IdCustomerNavigation { get; set; }
    
    public virtual ICollection<PeyGiryAttachment>? PeyGiryAttachments { get; set; } 
    
    public byte[] RowVersion { get; set; }
}