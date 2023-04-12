namespace Application.Services.ContactService.Commands;

public struct ChangeStatusContactCommand : IRequest<Contact?>
{
    public Ulid ContactId { get; set; }
    public Status ContactStatus { get; set; }
}