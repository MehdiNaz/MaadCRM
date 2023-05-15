namespace Domain.Models.Customers.PeyGiry;

public class PeyGiryCategory : BaseEntityWithUserUpdate
{
    public PeyGiryCategory()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
        CustomerPeyGiries = new HashSet<CustomerPeyGiry>();
    }

    public Ulid Id { get; set; }
    public required string Kind { get; set; }
    public StatusType Status { get; set; }
    public Ulid? BusinessId { get; set; }
    public Business IdBusinessNavigation { get; set; }
    public ICollection<CustomerPeyGiry>? CustomerPeyGiries { get; set; }
}