namespace Domain.Models.Contacts;

public class ContactPhoneNumber : BaseEntity
{
    public ContactPhoneNumber()
    {
        IsDeleted = (byte)Status.NotDeleted;
    }

    public Ulid ContactPhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public Ulid CustomerId { get; set; }
    public byte IsDeleted { get; set; }

    public ICollection<Contact> Contacts { get; set; }
}