namespace Application.Services.ContactService.Commands;

public struct ChangeStatusContactCommand : IRequest<Result<Contact>>
{
    public Ulid Id { get; set; }
    public Status ContactStatus { get; set; }
}