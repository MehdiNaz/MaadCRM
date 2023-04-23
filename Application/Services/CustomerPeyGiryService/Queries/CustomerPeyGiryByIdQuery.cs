namespace Application.Services.CustomerPeyGiryService.Queries;

public struct CustomerPeyGiryByIdQuery : IRequest<Result<CustomerPeyGiry>>
{
    public Ulid CustomerPeyGiryId { get; set; }
}