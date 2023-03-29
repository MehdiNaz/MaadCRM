namespace Application.Services.ContactService.Commands;

public class DeleteContactCommand : IRequest<Contact>
{
    public Ulid ContactId { get; set; }
}