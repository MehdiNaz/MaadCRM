namespace Domain.Models.Contacts;

public class ContactGroup:BaseEntity
{
    public string GtoupName { get; set; }
    public int DisplayOrder { get; set; }
    public ICollection<Contact> Contact { get; set; }
}