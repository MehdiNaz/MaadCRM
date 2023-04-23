namespace Application.Services.CustomerPeyGiryService.Commands;

public struct DeleteCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiry>>
{
    public Ulid Id { get; set; }
}
