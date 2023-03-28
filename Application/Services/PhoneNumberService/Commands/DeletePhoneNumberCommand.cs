namespace Application.Services.PhoneNumberService.Commands;

public class DeletePhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public Ulid PhoneNumberId { get; set; }
}