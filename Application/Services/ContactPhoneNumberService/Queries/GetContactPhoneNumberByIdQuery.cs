namespace Application.Services.ContactPhoneNumberService.Queries;

public class GetContactPhoneNumberByIdQuery : IRequest<ContactPhoneNumber>
{
    public Ulid ContactPhoneNumberId { get; set; }
}