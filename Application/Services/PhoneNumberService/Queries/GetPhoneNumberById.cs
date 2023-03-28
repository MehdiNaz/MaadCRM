namespace Application.Services.PhoneNumberService.Queries;

public class GetPhoneNumberById : IRequest<CustomersPhoneNumber?>
{
    public Ulid PhoneNumberId { get; set; }
}