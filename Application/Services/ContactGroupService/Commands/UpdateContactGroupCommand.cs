namespace Application.Services.ContactGroupService.Commands;

public class UpdateContactGroupCommand : IRequest<ContactGroup>
{
    public Ulid ContactGroupId { get; set; }
    public string ContactGroupName { get; set;}
    public int DisplayOrder { get; set; }
}