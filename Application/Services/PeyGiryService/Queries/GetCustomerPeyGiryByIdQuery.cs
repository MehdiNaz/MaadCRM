namespace Application.Services.PeyGiryService.Queries;

public struct GetCustomerPeyGiryByIdQuery : IRequest<CustomerPeyGiry>
{
    public Ulid CustomerPeyGiryId { get; set; }
}