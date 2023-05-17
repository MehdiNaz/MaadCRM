namespace Application.Services.Customer.CustomerPeyGiryService.Commands;

public struct CreateCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiryResponse>>
{
    public string? Description { get; set; }
    public DateTime? DatePeyGiry { get; set; }
    public Ulid CustomerId { get; set; }
    public string? IdUser { get; set; }
    public Ulid IdPeyGiryCategory { get; set; }
}