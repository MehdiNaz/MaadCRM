namespace Domain.Models.Contacts;

public class ContactsEmailAddress : BaseEntity
{
    public ContactsEmailAddress()
    {
        IsDeleted = (byte)Status.NotDeleted;
    }

    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public byte IsDeleted { get; set; }

    public ICollection<Contact> Contacts { get; set; }
}