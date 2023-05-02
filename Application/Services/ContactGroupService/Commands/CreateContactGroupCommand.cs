namespace Application.Services.ContactGroupService.Commands;

public struct CreateContactGroupCommand : IRequest<Result<ContactGroup>>
{
    public string UserId { get; set; }
    public string GroupName { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid BusinessId { get; set; }
}