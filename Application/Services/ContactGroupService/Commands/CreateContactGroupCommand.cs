namespace Application.Services.ContactGroupService.Commands;

public class CreateContactGroupCommand : IRequest<ContactGroup>
{
    public string GroupName { get; set; }
    public int DisplayOrder { get; set; }
}