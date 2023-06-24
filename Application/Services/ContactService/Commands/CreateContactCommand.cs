namespace Application.Services.ContactService.Commands;

public struct CreateContactCommand : IRequest<Result<ContactsResponse>>
{
    public string? FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<string>? EmailAddresses { get; set; }
    public ICollection<string> PhoneNumber { get; set; }
    public string? Job { get; set; }
    public string IdUser { get; set; }
    public Ulid ContactGroupId { get; set; }
}