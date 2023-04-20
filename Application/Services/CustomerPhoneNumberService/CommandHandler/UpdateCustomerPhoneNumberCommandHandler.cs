namespace Application.Services.CustomerPhoneNumberService.CommandHandler;

public readonly struct UpdateCustomerPhoneNumberCommandHandler : IRequestHandler<UpdateCustomerPhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public UpdateCustomerPhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(UpdateCustomerPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerPhoneNumberCommand item = new()
        {
            PhoneNo = request.PhoneNo,
            CustomerId = request.CustomerId
        };
        return await _repository.UpdatePhoneNumberAsync(item);
    }
}