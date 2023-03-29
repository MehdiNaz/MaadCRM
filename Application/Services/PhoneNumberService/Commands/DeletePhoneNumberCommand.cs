namespace Application.Services.PhoneNumberService.Commands;

public struct DeletePhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public Ulid PhoneNumberId { get; set; }
}