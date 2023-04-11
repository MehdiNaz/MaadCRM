namespace Domain.Models.Contacts;

public class Contact : BaseEntity
{
    public Contact()
    {
        ContactId = Ulid.NewUlid();
        ContactStatus = Status.Show;
    }

    public Ulid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Ulid MobileNumberId { get; set; }
    public Ulid EmailId { get; set; }
    public Ulid ContactGroupId { get; set; }
    public string Job { get; set; }
    public Ulid BusinessId { get; set; }
    public Status ContactStatus { get; set; }


    //public Business Business { get; set; }
    //public ContactsEmailAddress ContactsEmailAddress { get; set; }
    //public ContactPhoneNumber ContactPhoneNumber { get; set; }
    //public ContactGroup ContactGroup { get; set; }
}