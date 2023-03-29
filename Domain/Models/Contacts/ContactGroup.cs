namespace Domain.Models.Contacts;

public class ContactGroup : BaseEntity
{
    public ContactGroup()
    {
        IsDeleted = (byte)Status.NotDeleted;
    }

    public Ulid ContactGroupId { get; set; }
    public string GroupName { get; set; }
    public int DisplayOrder { get; set; }
    public byte IsDeleted { get; set; }

    public ICollection<Contact> Contacts { get; set; }
    public ICollection<Business> Businesses { get; set; }
}