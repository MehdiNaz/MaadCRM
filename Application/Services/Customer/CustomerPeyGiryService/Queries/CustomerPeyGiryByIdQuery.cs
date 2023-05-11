namespace Application.Services.Customer.CustomerPeyGiryService.Queries;

public struct CustomerPeyGiryByIdQuery : IRequest<Result<CustomerPeyGiry>>
{
    public Ulid CustomerPeyGiryId { get; set; }
}