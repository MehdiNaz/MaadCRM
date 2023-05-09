namespace Domain.Models.Contacts;

public class ContactsEmailAddress : BaseEntity
{
    public ContactsEmailAddress()
    {
        Id = Ulid.NewUlid();
        ContactsEmailAddressStatusType = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public Ulid ContactId { get; set; }
    public string ContactEmailAddress { get; set; }
    public StatusType ContactsEmailAddressStatusType { get; set; }

    public Contact? Contacts { get; set; }
}