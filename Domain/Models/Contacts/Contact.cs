namespace Domain.Models.Contacts;

public class Contact : BaseEntity
{
    public Contact()
    {
        Id = Ulid.NewUlid();
        ContactStatusType = StatusType.Show;
        ContactsEmailAddresses = new HashSet<ContactsEmailAddress>();
    }

    public Ulid Id { get; set; }
    public string? FirstName { get; set; }
    public string LastName { get; set; }
    public Ulid? MobileNumberId { get; set; }
    public Ulid? EmailId { get; set; }
    public string? Job { get; set; }
    public Ulid BusinessId { get; set; }
    public StatusType ContactStatusType { get; set; }

    public Ulid ContactGroupId { get; set; }
    public ContactGroup ContactGroup { get; set; }

    //public Business Business { get; set; }
    public ICollection<ContactsEmailAddress>? ContactsEmailAddresses { get; set; }
    public ICollection<ContactPhoneNumber>? ContactPhoneNumbers { get; set; }
}