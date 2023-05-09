namespace Application.Services.ContactService.Commands;

public struct ChangeStatusContactCommand : IRequest<Result<ContactsResponse>>
{
    public Ulid Id { get; set; }
    public StatusType ContactStatusType { get; set; }
}