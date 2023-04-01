namespace Domain.Models.Contacts;

public class ContactGroup : BaseEntity
{
    public ContactGroup()
    {
        ContactGroupId = Ulid.NewUlid();
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid ContactGroupId { get; set; }
    public string GroupName { get; set; }
    public int DisplayOrder { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public ICollection<Contact> Contacts { get; set; }
    public ICollection<Business> Businesses { get; set; }
}