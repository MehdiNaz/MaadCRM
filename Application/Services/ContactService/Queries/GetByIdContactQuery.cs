namespace Application.Services.ContactService.Queries;

public class GetByIdContactQuery : IRequest<Contact>
{
    public Ulid ContactId { get; set; }
}