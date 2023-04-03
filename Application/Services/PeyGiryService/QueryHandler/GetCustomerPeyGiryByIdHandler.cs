namespace Application.Services.PeyGiryService.QueryHandler;

public class GetCustomerPeyGiryByIdHandler : IRequestHandler<GetCustomerPeyGiryByIdQuery, CustomerPeyGiry>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public GetCustomerPeyGiryByIdHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerPeyGiry> Handle(GetCustomerPeyGiryByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetCustomerPeyGiryByIdAsync(request.CustomerPeyGiryId))!;
}