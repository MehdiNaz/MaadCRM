namespace Application.Services.CustomersEmailAddressService.CommandHandler;

public class CreateCustomersEmailAddressHandler : IRequestHandler<CreateCustomersEmailAddressCommand, CustomersEmailAddress>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public CreateCustomersEmailAddressHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersEmailAddress> Handle(CreateCustomersEmailAddressCommand request, CancellationToken cancellationToken)
    {
        CustomersEmailAddress item = new()
        {
            CustomersEmailAddrs = request.EmailAddrs,
        };
        await _repository.CreateEmailAddressAsync(item);

        return item;
    }
}