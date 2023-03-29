namespace Application.Services.ContactPhoneNumberService.Queries;

public struct GetContactPhoneNumberByIdQuery : IRequest<ContactPhoneNumber>
{
    public Ulid ContactPhoneNumberId { get; set; }
}