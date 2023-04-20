namespace Application.Services.ContactGroupService.Commands;

public struct UpdateContactGroupCommand : IRequest<ContactGroup>
{
    public Ulid Id { get; set; }
    public string GroupName { get; set;}
    public int DisplayOrder { get; set; }
}