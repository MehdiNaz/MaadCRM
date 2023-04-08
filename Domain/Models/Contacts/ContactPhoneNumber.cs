namespace Domain.Models.Contacts;

public class ContactPhoneNumber : BaseEntity
{
    public ContactPhoneNumber()
    {
        ContactPhoneNumberId = Ulid.NewUlid();
        ContactPhoneNumberStatus = Status.Show;
    }

    public Ulid ContactPhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public Status ContactPhoneNumberStatus { get; set; }

    public ICollection<Contact>? Contacts { get; set; }
}