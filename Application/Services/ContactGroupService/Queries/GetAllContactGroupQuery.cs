namespace Application.Services.ContactGroupService.Queries;

public struct GetAllContactGroupQuery : IRequest<Result<ICollection<ContactGroup>>>
{
}