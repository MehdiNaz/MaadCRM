namespace Application.Services.PhoneNumberService.CommandHandlers;

public class CreatePhoneNumberCommandHandler : IRequestHandler<CreatePhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public CreatePhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(CreatePhoneNumberCommand request, CancellationToken cancellationToken)
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
