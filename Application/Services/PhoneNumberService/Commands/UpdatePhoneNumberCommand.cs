namespace Application.Services.PhoneNumberService.Commands;

public class UpdatePhoneNumberCommand : IRequest<PhoneNumber>
{
    public Ulid PhoneNumberId { get; set; }
    public string PhoneNo { get; set; }
    public int PhoneType { get; set; }
    public Ulid CustomerId { get; set; }
    public byte IsDeleted { get; set; }
}