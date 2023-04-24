namespace Application.Services.CustomersEmailAddressService.CommandHandler;

public readonly struct UpdateCustomersEmailAddressCommandHandler : IRequestHandler<UpdateCustomersEmailAddressCommand, CustomersEmailAddress>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public UpdateCustomersEmailAddressCommandHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersEmailAddress> Handle(UpdateCustomersEmailAddressCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomersEmailAddressCommand item = new()
        {
            Id = request.Id,
            EmailAddress = request.EmailAddress,
            CustomerId = request.CustomerId,
            IdUser = request.IdUser
        };
        return await _repository.UpdateEmailAddressAsync(item);
    }
}