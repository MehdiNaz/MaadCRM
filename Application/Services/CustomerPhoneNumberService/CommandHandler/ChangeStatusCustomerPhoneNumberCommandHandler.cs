namespace Application.Services.CustomerPhoneNumberService.CommandHandler;

public readonly struct ChangeStatusCustomerPhoneNumberCommandHandler : IRequestHandler<ChangeStatusCustomerPhoneNumberCommand, CustomersPhoneNumber?>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public ChangeStatusCustomerPhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber?> Handle(ChangeStatusCustomerPhoneNumberCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusPhoneNumberByIdAsync(request);
}