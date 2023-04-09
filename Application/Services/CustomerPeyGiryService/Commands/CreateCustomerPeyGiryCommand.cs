namespace Application.Services.CustomerPeyGiryService.Commands;

public struct CreateCustomerPeyGiryCommand : IRequest<CustomerPeyGiry>
{
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
}