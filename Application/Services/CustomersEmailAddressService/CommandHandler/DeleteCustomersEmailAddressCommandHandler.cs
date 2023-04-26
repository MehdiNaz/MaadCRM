namespace Application.Services.CustomersEmailAddressService.CommandHandler;

public readonly struct DeleteCustomersEmailAddressCommandHandler : IRequestHandler<DeleteCustomersEmailAddressCommand, CustomersEmailAddress>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public DeleteCustomersEmailAddressCommandHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersEmailAddress> Handle(DeleteCustomersEmailAddressCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteEmailAddressAsync(request.Id))!;
}