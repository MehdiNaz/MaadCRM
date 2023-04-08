namespace Domain.Models.Contacts;

public class ContactsEmailAddress : BaseEntity
{
    public ContactsEmailAddress()
    {
        CustomersEmailAddressId = Ulid.NewUlid();
        ContactsEmailAddressStatus = Status.Show;
    }

    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public Status ContactsEmailAddressStatus { get; set; }

    public ICollection<Contact>? Contacts { get; set; }
}