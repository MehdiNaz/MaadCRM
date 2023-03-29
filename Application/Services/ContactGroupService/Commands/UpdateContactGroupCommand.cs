namespace Application.Services.ContactGroupService.Commands;

public struct UpdateContactGroupCommand : IRequest<ContactGroup>
{
    public Ulid ContactGroupId { get; set; }
    public string ContactGroupName { get; set;}
    public int DisplayOrder { get; set; }
}