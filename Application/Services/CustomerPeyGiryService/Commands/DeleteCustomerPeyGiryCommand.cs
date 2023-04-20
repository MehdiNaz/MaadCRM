namespace Application.Services.CustomerPeyGiryService.Commands;

public struct DeleteCustomerPeyGiryCommand : IRequest<CustomerPeyGiry>
{
    public Ulid Id { get; set; }
}
