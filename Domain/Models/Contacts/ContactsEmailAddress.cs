namespace Domain.Models.Contacts;

public class ContactsEmailAddress : BaseEntity
{
    public ContactsEmailAddress()
    {
        Id = Ulid.NewUlid();
        ContactsEmailAddressStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public Status ContactsEmailAddressStatus { get; set; }

    public ICollection<Contact>? Contacts { get; set; }
}