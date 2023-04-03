namespace Application.Services.PeyGiryService.QueryHandler;

public class GetAllCustomerPeyGiryHandler : IRequestHandler<GetAllCustomerPeyGiryQuery, ICollection<CustomerPeyGiry>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public GetAllCustomerPeyGiryHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerPeyGiry>> Handle(GetAllCustomerPeyGiryQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllCustomerPeyGiriessAsync())!;
}