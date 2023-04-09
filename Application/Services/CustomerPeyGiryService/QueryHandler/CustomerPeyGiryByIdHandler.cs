namespace Application.Services.CustomerPeyGiryService.QueryHandler;

public readonly struct CustomerPeyGiryByIdHandler : IRequestHandler<CustomerPeyGiryByIdQuery, CustomerPeyGiry>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public CustomerPeyGiryByIdHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerPeyGiry> Handle(CustomerPeyGiryByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetCustomerPeyGiryByIdAsync(request.CustomerPeyGiryId))!;
}