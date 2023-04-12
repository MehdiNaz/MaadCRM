namespace Application.Services.CustomerPhoneNumberService.Commands;

public struct ChangeStatusCustomerPhoneNumberCommand : IRequest<CustomersPhoneNumber?>
{
    public Ulid ContactPhoneNumberId { get; set; }
    public Status ContactPhoneNumberStatus { get; set; }
}