namespace Application.Services.ContactService.Commands;

public class UpdateContactCommand : IRequest<Contact>
{
    public Ulid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Ulid EmailId { get; set; }
    public Ulid ContactGroupId { get; set; }
    public string Job { get; set; }
    public byte IsDeleted { get; set; }
    public Ulid BusinessId { get; set; }
}