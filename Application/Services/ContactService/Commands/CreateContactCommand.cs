namespace Application.Services.ContactService.Commands;

public struct CreateContactCommand : IRequest<Result<ContactsResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Ulid EmailId { get; set; }
    public string Job { get; set; }
    public Ulid BusinessId { get; set; }
    public Ulid ContactGroupId { get; set; }
}