namespace Application.Services.CustomerPeyGiryService.Queries;

public struct AllCustomerPeyGiriesQuery : IRequest<Result<ICollection<CustomerPeyGiryResponse>>>
{
    public Ulid CustomerId { get; set; }
}