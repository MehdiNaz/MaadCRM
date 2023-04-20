namespace Application.Services.ContactGroupService.Commands;

public struct ChangeStatusContactGroupCommand : IRequest<ContactGroup?>
{
    public Ulid ContactGroupId { get; set; }
    public Status ContactGroupStatus { get; set; }
}