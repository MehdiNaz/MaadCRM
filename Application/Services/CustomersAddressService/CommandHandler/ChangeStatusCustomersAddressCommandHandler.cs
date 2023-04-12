namespace Application.Services.CustomersAddressService.CommandHandler;

public readonly struct ChangeStatusCustomersAddressCommandHandler : IRequestHandler<ChangeStatusCustomersAddressCommand, CustomersAddress?>
{
    private readonly ICustomersAddressRepository _repository;

    public ChangeStatusCustomersAddressCommandHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersAddress?> Handle(ChangeStatusCustomersAddressCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusAddressByIdAsync(request.CustomersAddressStatus, request.CustomersAddressId);
}