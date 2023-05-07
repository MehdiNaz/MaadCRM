namespace Domain.Models.Customers.PeyGiry;

public sealed class CustomerPeyGiry : BaseEntityWithUserUpdate
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
    public Customer? IdCustomerNavigation { get; set; }

    public ICollection<PeyGiryAttachment>? PeyGiryAttachments { get; set; }
}