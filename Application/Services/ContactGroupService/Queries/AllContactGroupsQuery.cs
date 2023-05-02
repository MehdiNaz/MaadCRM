namespace Application.Services.ContactGroupService.Queries;

public struct AllContactGroupsQuery : IRequest<Result<ICollection<ContactGroup>>>
{
    public string UserId { get; set; }
}