namespace Application.Services.ContactService.Queries;

public struct ContactByGroupIdQuery : IRequest<Result<ICollection<ContactsResponse>>>
{
    public Ulid ContactGroupId { get; set; }
}
