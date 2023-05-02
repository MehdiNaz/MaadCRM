namespace Application.Services.ContactGroupService.Commands;

public struct DeleteContactGroupCommand : IRequest<Result<ContactGroup>>
{
    public Ulid Id { get; set; }
}