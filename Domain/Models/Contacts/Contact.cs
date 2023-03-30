namespace Domain.Models.Contacts;

public class Contact : BaseEntity
{
    public Contact()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Ulid MobileNumberId { get; set; }
    public Ulid EmailId { get; set; }
    public Ulid ContactGroupId { get; set; }
    public string Job { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }
    public Ulid BusinessId { get; set; }
    //[ForeignKey(nameof(ContactGroupId))]


    public ICollection<Business> Businesses { get; set; }
    public ContactsEmailAddress ContactsEmailAddress { get; set; }
    public ContactPhoneNumber ContactPhoneNumber { get; set; }
    public ContactGroup ContactGroup { get; set; }
}