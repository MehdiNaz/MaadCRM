namespace Application.Services.ContactGroupService.Queries;

public struct ContactGroupByIdQuery : IRequest<Result<ContactGroup>>
{
    public Ulid ContactGroupId { get; set; }
}