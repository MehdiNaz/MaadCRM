namespace Application.Services.ContactService.Queries;

public struct ContactByIdQuery : IRequest<Result<ContactsResponse>>
{
    public Ulid ContactId { get; set; }
}