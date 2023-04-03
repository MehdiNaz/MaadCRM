namespace Application.Services.CustomerPhoneNumberService.CommandHandler;

public class CustomerPhoneNumberCommandHandler : IRequestHandler<CreateCustomerPhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public CustomerPhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(CreateCustomerPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        CustomersPhoneNumber item = new()
        {
            PhoneNo = request.PhoneNo,
            PhoneType = request.PhoneType,
            CustomerId = request.CustomerId
        };
        await _repository.CreatePhoneNumberAsync(item);
        return item;
    }
}
