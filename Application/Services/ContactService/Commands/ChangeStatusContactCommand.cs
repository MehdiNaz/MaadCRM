namespace Application.Services.ContactService.Commands;

public struct ChangeStatusContactCommand : IRequest<Contact?>
{
    public Ulid Id { get; set; }
    public Status ContactStatus { get; set; }
}