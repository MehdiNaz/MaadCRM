namespace Application.Services.ContactGroupService.Commands;

public class DeleteContactGroupCommand : IRequest<ContactGroup>
{
    public Ulid ContactGroupId { get; set; }
}