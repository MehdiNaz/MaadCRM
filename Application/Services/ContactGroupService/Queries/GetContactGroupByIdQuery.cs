namespace Application.Services.ContactGroupService.Queries;

public struct GetContactGroupByIdQuery : IRequest<ContactGroup>
{
    public Ulid ContactGroupId { get; set; }
}