namespace Application.Services.PhoneNumberService.CommandHandlers;

public class UpdatePhoneNumberCommandHandler : IRequestHandler<UpdatePhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public UpdatePhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken)
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
