namespace Application.Services.EmailAddressService.CommandHandler;

public class UpdateCustomersEmailAddressHandler : IRequestHandler<UpdateCustomersEmailAddressCommand, CustomersEmailAddress>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public UpdateCustomersEmailAddressHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersEmailAddress> Handle(UpdateCustomersEmailAddressCommand request, CancellationToken cancellationToken)
    {
        CustomersEmailAddress item = new()
        {
            CustomersEmailAddrs = request.EmailAddrs
        };
        await _repository.UpdateEmailAddressAsync(item, request.EmailAddressId);
        return item;
    }
}