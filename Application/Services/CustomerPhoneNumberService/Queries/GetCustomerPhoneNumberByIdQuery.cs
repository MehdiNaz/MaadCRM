namespace Application.Services.CustomerPhoneNumberService.Queries;

public struct GetCustomerPhoneNumberByIdQuery : IRequest<CustomersPhoneNumber>
{
    public Ulid PhoneNumberId { get; set; }
}