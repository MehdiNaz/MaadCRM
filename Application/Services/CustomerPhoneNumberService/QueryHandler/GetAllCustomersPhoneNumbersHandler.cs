namespace Application.Services.CustomerPhoneNumberService.QueryHandler;

public readonly struct GetAllCustomersPhoneNumbersHandler : IRequestHandler<GetAllCustomersPhoneNumbersQuery, ICollection<CustomersPhoneNumber>>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public GetAllCustomersPhoneNumbersHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomersPhoneNumber>> Handle(GetAllCustomersPhoneNumbersQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllPhoneNumbersAsync())!;
}