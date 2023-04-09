namespace Application.Services.CustomerPeyGiryService.Commands;

public struct UpdateCustomerPeyGiryCommand : IRequest<CustomerPeyGiry>
{
    public Ulid CustomerPeyGiryId { get; set; }
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
}