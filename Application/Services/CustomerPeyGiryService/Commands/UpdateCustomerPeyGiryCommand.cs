namespace Application.Services.CustomerPeyGiryService.Commands;

public struct UpdateCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiry>>
{
    public Ulid Id { get; set; }
    public DateTime DatePeyGiry { get; set; }
    public string Description { get; set; }
    public string? IdUser { get; set; }
}