namespace Application.Services.CustomerPhoneNumberService.CommandHandler;

public class UpdateCustomerPhoneNumberCommandHandler : IRequestHandler<UpdateCustomerPhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public UpdateCustomerPhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(UpdateCustomerPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        CustomersPhoneNumber item = new()
        {
            PhoneNo = request.PhoneNo,
            PhoneType = request.PhoneType,
            CustomerId = request.CustomerId
        };
        await _repository.UpdatePhoneNumberAsync(item, request.PhoneNumberId);
        return item;
    }
}