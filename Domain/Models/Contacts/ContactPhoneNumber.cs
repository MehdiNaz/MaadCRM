namespace Domain.Models.Contacts;

public class ContactPhoneNumber : BaseEntity
{
    public ContactPhoneNumber()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid ContactPhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public PhoneTypes PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public ICollection<Contact> Contacts { get; set; }
}