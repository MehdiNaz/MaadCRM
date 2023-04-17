namespace Application.Services.CustomerPeyGiryService.QueryHandler;

public readonly struct AllCustomerPeyGiryHandler : IRequestHandler<AllCustomerPeyGiriesQuery, ICollection<CustomerPeyGiryResponse>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public AllCustomerPeyGiryHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerPeyGiryResponse>> Handle(AllCustomerPeyGiriesQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllCustomerPeyGiriesAsync(request.CustomerId))!;
}