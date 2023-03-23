namespace Domain.Models.Contacts;

public class Contact:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public int ContactGroupId { get; set; }
    public string Job { get; set; }
    [ForeignKey(nameof(ContactGroupId))]
    public ContactGroup ContactGroup { get; set; }
        
}