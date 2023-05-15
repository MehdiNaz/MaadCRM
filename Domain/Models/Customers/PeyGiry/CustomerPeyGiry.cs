namespace Domain.Models.Customers.PeyGiry;

public sealed class CustomerPeyGiry : BaseEntityWithUserUpdate
{
    public CustomerPeyGiry()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
        Logs = new HashSet<Log>();
        PeyGiryAttachments = new HashSet<PeyGiryAttachment>();
    }

    public Ulid Id { get; set; }
    public required string Description { get; set; }
    public StatusType Status { get; set; }
    public DateTime DatePeyGiry { get; set; }

    public required Ulid IdCustomer { get; set; }
    public Customer? IdCustomerNavigation { get; set; }

    public Ulid IdPeyGiryCategory { get; set; }
    public PeyGiryCategory IdPeyGiryCategoryNavigation { get; set; }

    public ICollection<Log>? Logs { get; set; }
    public ICollection<PeyGiryAttachment>? PeyGiryAttachments { get; set; }
}