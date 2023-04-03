namespace Application.Services.CustomersEmailAddressService.CommandHandler;

public class UpdateCustomersEmailAddressCommandHandler : IRequestHandler<UpdateCustomersEmailAddressCommand, CustomersEmailAddress>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public UpdateCustomersEmailAddressCommandHandler(ICustomersEmailAddressRepository repository)
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