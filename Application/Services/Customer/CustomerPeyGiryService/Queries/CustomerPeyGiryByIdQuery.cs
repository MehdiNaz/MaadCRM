namespace Application.Services.Customer.CustomerPeyGiryService.Queries;

public struct CustomerPeyGiryByIdQuery : IRequest<Result<CustomerPeyGiryResponse>>
{
    public Ulid CustomerPeyGiryId { get; set; }
}