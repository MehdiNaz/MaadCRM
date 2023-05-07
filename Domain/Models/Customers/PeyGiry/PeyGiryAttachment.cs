namespace Domain.Models.Customers.PeyGiry;

public class PeyGiryAttachment : BaseEntity
{
    public PeyGiryAttachment()
    {
        Id = Ulid.NewUlid();
        StatusPeyGiryAttachment = Status.Show;
    }

    public Ulid Id { get; set; }
    public required byte[] FileName { get; set; }
    public string Extenstion { get; set; }
    public Status StatusPeyGiryAttachment { get; set; }
    
    
    public Ulid IdPeyGiry { get; set; }
    public virtual CustomerPeyGiry? IdCustomerPeyGiryNavigation { get; set; }
}