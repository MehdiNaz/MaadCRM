namespace Application.Services.PhoneNumberService.QueryHandlers;

public readonly struct GetAllPhoneNumberHandler : IRequestHandler<GetAllPhoneNumberQuery, ICollection<CustomersPhoneNumber?>>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public GetAllPhoneNumberHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomersPhoneNumber?>> Handle(GetAllPhoneNumberQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllPhoneNumbersAsync();
}