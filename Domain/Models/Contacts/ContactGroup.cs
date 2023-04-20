namespace Domain.Models.Contacts;

public class ContactGroup : BaseEntity
{
    public ContactGroup()
    {
        Id = Ulid.NewUlid();
        ContactGroupStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public string GroupName { get; set; }
    public int DisplayOrder { get; set; }
    public Status ContactGroupStatus { get; set; }
    public Ulid BusinessId { get; set; }

    //public Business Business { get; set; }
    public ICollection<Contact>? Contacts { get; set; }
}