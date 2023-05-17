namespace Application.Services.Customer.CustomerPeyGiryService.Commands;

public struct UpdateCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiryResponse>>
{
    public Ulid Id { get; set; }
    public DateTime DatePeyGiry { get; set; }
    public string? Description { get; set; }
    public string? IdUser { get; set; }
}