namespace Application.Services.CustomerPeyGiryService.Queries;

public struct AllCustomerPeyGiriesQuery : IRequest<ICollection<CustomerPeyGiry>>
{
    public Ulid CustomerId { get; set; }
}