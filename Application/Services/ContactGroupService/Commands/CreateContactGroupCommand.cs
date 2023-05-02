namespace Application.Services.ContactGroupService.Commands;

public struct CreateContactGroupCommand : IRequest<Result<ContactGroup>>
{
    public string GroupName { get; set; }
    public int DisplayOrder { get; set; }
}