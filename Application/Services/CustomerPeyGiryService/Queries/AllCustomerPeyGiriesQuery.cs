namespace Application.Services.CustomerPeyGiryService.Queries;

public struct AllCustomerPeyGiriesQuery : IRequest<ICollection<CustomerPeyGiryResponse>>
{
    public Ulid CustomerId { get; set; }
}