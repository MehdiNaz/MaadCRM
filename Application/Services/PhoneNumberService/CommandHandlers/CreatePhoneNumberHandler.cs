namespace Application.Services.PhoneNumberService.CommandHandlers;

public class CreatePhoneNumberHandler : IRequestHandler<CreatePhoneNumberCommand, PhoneNumber>
{
    private readonly IPhoneNumberRepository _repository;

    public CreatePhoneNumberHandler(IPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<PhoneNumber> Handle(CreatePhoneNumberCommand request, CancellationToken cancellationToken)
    {
        PhoneNumber item = new()
        {
            PhoneNo = request.PhoneNo,
            PhoneType = request.PhoneType,
            CustomerId = request.CustomerId,
            IsDeleted = request.IsDeleted
        };
        await _repository.CreatePhoneNumberAsync(item);
        return item;
    }
}
