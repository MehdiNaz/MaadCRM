namespace Application.Services.ContactGroupService.Queries;

public class GetContactGroupByIdQuery : IRequest<ContactGroup>
{
    public Ulid ContactGroupId { get; set; }
}