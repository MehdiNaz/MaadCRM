namespace Application.Services.CustomerPeyGiryService.Commands;

public struct DeleteCustomerPeyGiryCommand : IRequest<CustomerPeyGiry>
{
    public Ulid CustomerPeyGiryId { get; set; }
}
