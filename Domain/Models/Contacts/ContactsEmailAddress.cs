namespace Domain.Models.Contacts;

public class ContactsEmailAddress : BaseEntity
{
    public ContactsEmailAddress()
    {
        Id = Ulid.NewUlid();
        ContactsEmailAddressStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public Ulid ContactId { get; set; }
    public string ContactEmailAddress { get; set; }
    public Status ContactsEmailAddressStatus { get; set; }

    public Contact? Contacts { get; set; }
}