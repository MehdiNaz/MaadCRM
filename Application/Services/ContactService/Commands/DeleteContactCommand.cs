namespace Application.Services.ContactService.Commands;

public struct DeleteContactCommand : IRequest<Result<Contact>>
{
    public Ulid ContactId { get; set; }
}