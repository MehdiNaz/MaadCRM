namespace Application.Services.EmailAddressService.CommandHandler;

public class DeleteCustomersEmailAddressHandler : IRequestHandler<DeleteCustomersEmailAddressCommand, CustomersEmailAddress>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public DeleteCustomersEmailAddressHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersEmailAddress> Handle(DeleteCustomersEmailAddressCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteEmailAddressAsync(request.EmailAddressId))!;
}