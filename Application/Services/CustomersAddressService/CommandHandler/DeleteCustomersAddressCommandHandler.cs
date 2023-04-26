namespace Application.Services.CustomersAddressService.CommandHandler;

public readonly struct DeleteCustomersAddressCommandHandler : IRequestHandler<DeleteCustomersAddressCommand, CustomerAddress>
{
    private readonly ICustomersAddressRepository _repository;

    public DeleteCustomersAddressCommandHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerAddress> Handle(DeleteCustomersAddressCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteAddressAsync(request.Id))!;
}