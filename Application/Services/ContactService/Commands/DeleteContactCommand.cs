namespace Application.Services.ContactService.Commands;

public struct DeleteContactCommand : IRequest<Contact>
{
    public Ulid ContactId { get; set; }
}