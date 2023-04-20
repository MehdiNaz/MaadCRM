namespace Application.Services.ContactGroupService.Commands;

public struct DeleteContactGroupCommand : IRequest<ContactGroup>
{
    public Ulid Id { get; set; }
}