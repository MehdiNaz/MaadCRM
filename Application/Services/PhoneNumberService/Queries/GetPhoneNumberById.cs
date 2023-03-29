namespace Application.Services.PhoneNumberService.Queries;

public struct GetPhoneNumberById : IRequest<CustomersPhoneNumber?>
{
    public Ulid PhoneNumberId { get; set; }
}