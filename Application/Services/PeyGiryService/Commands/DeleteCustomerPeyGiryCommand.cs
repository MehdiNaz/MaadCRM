namespace Application.Services.PeyGiryService.Commands;

public struct DeleteCustomerPeyGiryCommand : IRequest<CustomerPeyGiry>
{
    public Ulid CustomerPeyGiryId { get; set; }
}