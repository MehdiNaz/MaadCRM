namespace Application.Services.CustomersEmailAddressService.CommandHandler;

public readonly struct ChangeStatusCustomersEmailAddressCommandHandler : IRequestHandler<ChangeStatusCustomersEmailAddressCommand, CustomersEmailAddress?>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public ChangeStatusCustomersEmailAddressCommandHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersEmailAddress?> Handle(ChangeStatusCustomersEmailAddressCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusEmailAddressByIdAsync(request);
}