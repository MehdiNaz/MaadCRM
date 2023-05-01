namespace Application.Services.ContactGroupService.Queries;

public struct ContactGroupBySearchItemQuery : IRequest<Result<ICollection<ContactGroup>>>
{
    public string Q { get; set; }
}
