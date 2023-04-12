namespace Application.Services.CustomerPeyGiryService.Commands;

public struct ChangeStatusCustomerPeyGiryCommand : IRequest<CustomerPeyGiry?>
{
    public Ulid CustomerPeyGiryId { get; set; }
    public Status CustomerPeyGiryStatus { get; set; }
}