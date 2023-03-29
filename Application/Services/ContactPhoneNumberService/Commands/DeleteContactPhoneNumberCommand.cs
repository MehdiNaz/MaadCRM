namespace Application.Services.ContactPhoneNumberService.Commands;

public class DeleteContactPhoneNumberCommand : IRequest<ContactPhoneNumber>
{
    public Ulid ContactPhoneNumberId { get; set; }
}