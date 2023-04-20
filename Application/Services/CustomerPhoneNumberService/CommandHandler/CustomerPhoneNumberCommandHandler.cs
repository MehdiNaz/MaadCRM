namespace Application.Services.CustomerPhoneNumberService.CommandHandler;

public readonly struct CustomerPhoneNumberCommandHandler : IRequestHandler<CreateCustomerPhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public CustomerPhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(CreateCustomerPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerPhoneNumberCommand item = new()
        {
            PhoneNo = request.PhoneNo,
            CustomerId = request.CustomerId
        };
        return await _repository.CreatePhoneNumberAsync(item);
    }
}
