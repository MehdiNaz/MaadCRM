namespace Application.Services.CustomerPeyGiryService.Commands;

public struct ChangeStatusCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiry>>
{
    public Ulid CustomerPeyGiryId { get; set; }
    public Status CustomerPeyGiryStatus { get; set; }
}