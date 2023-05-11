namespace Application.Services.Customer.CustomerPeyGiryService.Queries;

public struct AllCustomerPeyGiriesQuery : IRequest<Result<ICollection<CustomerPeyGiryResponse>>>
{
    public Ulid CustomerId { get; set; }
    public string UserId { get; set; }
}