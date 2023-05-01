namespace Application.Services.ContactService.Queries;

public struct ContactByIdQuery : IRequest<Result<Contact>>
{
    public Ulid ContactId { get; set; }
}