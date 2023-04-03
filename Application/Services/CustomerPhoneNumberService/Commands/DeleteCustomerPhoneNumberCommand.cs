namespace Application.Services.CustomerPhoneNumberService.Commands;

public struct DeleteCustomerPhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public Ulid PhoneNumberId { get; set; }
}