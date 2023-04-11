namespace Application.Services.CustomerPhoneNumberService.QueryHandler;

public readonly struct GetCustomersPhoneNumberByIdHandler : IRequestHandler<GetCustomerPhoneNumberByIdQuery, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public GetCustomersPhoneNumberByIdHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(GetCustomerPhoneNumberByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetPhoneNumberByIdAsync(request.PhoneNumberId))!;
}