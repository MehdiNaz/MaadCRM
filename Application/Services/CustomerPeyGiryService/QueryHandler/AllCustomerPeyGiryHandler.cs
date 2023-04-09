namespace Application.Services.CustomerPeyGiryService.QueryHandler;

public readonly struct AllCustomerPeyGiryHandler : IRequestHandler<AllCustomerPeyGiriesQuery, ICollection<CustomerPeyGiry>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public AllCustomerPeyGiryHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerPeyGiry>> Handle(AllCustomerPeyGiriesQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllCustomerPeyGiriesAsync())!;
}