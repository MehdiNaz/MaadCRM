namespace Domain.Models.Contacts;

public class ContactGroup : BaseEntity
{
    public ContactGroup()
    {
        ContactGroupId = Ulid.NewUlid();
        ContactGroupStatus = Status.Show;
    }

    public Ulid ContactGroupId { get; set; }
    public string GroupName { get; set; }
    public int DisplayOrder { get; set; }
    public Status ContactGroupStatus { get; set; }

    public ICollection<Contact> Contacts { get; set; }
    public ICollection<Business> Businesses { get; set; }
}