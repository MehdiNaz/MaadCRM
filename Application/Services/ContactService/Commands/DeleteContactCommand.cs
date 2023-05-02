namespace Application.Services.ContactService.Commands;

public struct DeleteContactCommand : IRequest<Result<ContactsResponse>>
{
    public Ulid ContactId { get; set; }
}