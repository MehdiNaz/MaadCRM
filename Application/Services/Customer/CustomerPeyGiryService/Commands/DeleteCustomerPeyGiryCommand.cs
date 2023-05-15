namespace Application.Services.Customer.CustomerPeyGiryService.Commands;

public struct DeleteCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiryResponse>>
{
    public Ulid Id { get; set; }
}
