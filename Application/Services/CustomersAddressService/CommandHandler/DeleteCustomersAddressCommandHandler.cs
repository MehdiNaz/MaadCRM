namespace Application.Services.CustomersAddressService.CommandHandler;

public readonly struct DeleteCustomersAddressCommandHandler : IRequestHandler<DeleteCustomersAddressCommand, CustomersAddress>
{
    private readonly ICustomersAddressRepository _repository;

    public DeleteCustomersAddressCommandHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersAddress> Handle(DeleteCustomersAddressCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteAddressAsync(request))!;
}