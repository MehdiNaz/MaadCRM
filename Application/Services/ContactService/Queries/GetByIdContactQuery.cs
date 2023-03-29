namespace Application.Services.ContactService.Queries;

public struct GetByIdContactQuery : IRequest<Contact>
{
    public Ulid ContactId { get; set; }
}