namespace Application.Services.PhoneNumberService.Queries;

public class GetPhoneNumberById : IRequest<PhoneNumber?>
{
    public Ulid PhoneNumberId { get; set; }
}