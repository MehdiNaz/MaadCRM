namespace Domain.Models.Contacts;

public class ContactsEmailAddress : BaseEntity
{
    public ContactsEmailAddress()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public ICollection<Contact> Contacts { get; set; }
}