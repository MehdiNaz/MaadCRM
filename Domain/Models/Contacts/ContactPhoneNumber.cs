namespace Domain.Models.Contacts;

public class ContactPhoneNumber : BaseEntity
{
    public ContactPhoneNumber()
    {
        Id = Ulid.NewUlid();
        ContactPhoneNumberStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public Status ContactPhoneNumberStatus { get; set; }

    public ICollection<Contact>? Contacts { get; set; }
}