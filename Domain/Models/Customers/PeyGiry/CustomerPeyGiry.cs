namespace Domain.Models.Customers.PeyGiry;

public sealed class CustomerPeyGiry : BaseEntityWithUserUpdate
{
    public CustomerPeyGiry()
    {
        Id = Ulid.NewUlid();
        StatusTypeCustomerPeyGiry = StatusType.Show;
        PeyGiryAttachments = new HashSet<PeyGiryAttachment>();
        Logs = new HashSet<Log>();
    }

    public Ulid Id { get; set; }
    public required string Description { get; set; }
    public StatusType StatusTypeCustomerPeyGiry { get; set; }
    public DateTime DatePeyGiry { get; set; }

    public required Ulid IdCustomer { get; set; }
    public Customer? IdCustomerNavigation { get; set; }

    public ICollection<PeyGiryAttachment>? PeyGiryAttachments { get; set; }
    public ICollection<Log>? Logs { get; set; }
}