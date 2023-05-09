namespace Domain.Models.Contacts;

public class ContactPhoneNumber : BaseEntity
{
    public ContactPhoneNumber()
    {
        Id = Ulid.NewUlid();
        ContactPhoneNumberStatusType = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public Ulid ContactId { get; set; }
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public StatusType ContactPhoneNumberStatusType { get; set; }

    public Contact? Contacts { get; set; }
}