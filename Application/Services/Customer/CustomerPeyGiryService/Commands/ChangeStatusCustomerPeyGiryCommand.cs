namespace Application.Services.Customer.CustomerPeyGiryService.Commands;

public struct ChangeStatusCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiryResponse>>
{
    public Ulid CustomerPeyGiryId { get; set; }
    public StatusType CustomerPeyGiryStatusType { get; set; }
}