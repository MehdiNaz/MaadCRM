namespace Application.Services.ContactGroupService.Commands;

public struct ChangeStateContactGroupCommand : IRequest<ContactGroup?>
{
    public Ulid ContactGroupId { get; set; }
    public Status ContactGroupStatus { get; set; }
}