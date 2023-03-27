namespace Application.Services.PhoneNumberService.Commands;

public class DeletePhoneNumberCommand : IRequest<PhoneNumber>
{
    public Ulid PhoneNumberId { get; set; }
}