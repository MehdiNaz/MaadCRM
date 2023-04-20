namespace Application.Services.CustomersEmailAddressService.CommandHandler;

public readonly struct CreateCustomersEmailAddressCommandHandler : IRequestHandler<CreateCustomersEmailAddressCommand, CustomersEmailAddress>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public CreateCustomersEmailAddressCommandHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersEmailAddress> Handle(CreateCustomersEmailAddressCommand request, CancellationToken cancellationToken)
    {
        CreateCustomersEmailAddressCommand item = new()
        {
            EmailAddress = request.EmailAddress,
            CustomerId = request.CustomerId
        };
        return await _repository.CreateEmailAddressAsync(item);
    }
}