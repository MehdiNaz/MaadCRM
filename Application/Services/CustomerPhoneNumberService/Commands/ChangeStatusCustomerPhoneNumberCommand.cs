namespace Application.Services.CustomerPhoneNumberService.Commands;

public struct ChangeStatusCustomerPhoneNumberCommand : IRequest<CustomersPhoneNumber>
{
    public Ulid Id { get; set; }
    public Status ContactPhoneNumberStatus { get; set; }
}