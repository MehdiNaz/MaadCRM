namespace Application.Services.CustomerPeyGiryService.Queries;

public struct CustomerPeyGiryByIdQuery : IRequest<CustomerPeyGiry>
{
    public Ulid CustomerPeyGiryId { get; set; }
}