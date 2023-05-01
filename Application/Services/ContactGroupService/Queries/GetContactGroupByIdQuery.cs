namespace Application.Services.ContactGroupService.Queries;

public struct GetContactGroupByIdQuery : IRequest<Result<ContactGroup>>
{
    public Ulid ContactGroupId { get; set; }
}