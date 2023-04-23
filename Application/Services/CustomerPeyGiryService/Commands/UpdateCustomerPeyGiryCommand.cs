namespace Application.Services.CustomerPeyGiryService.Commands;

public struct UpdateCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiry>>
{
    public Ulid Id { get; set; }
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
    public required string IdUserAdded { get; set; }
    public required string IdUserUpdated { get; set; }
}